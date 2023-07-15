import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RouteInterface } from 'src/app/admin/interface/route';
import { RouteService } from '../../services/route/route.service';
import ValidateForm from 'src/app/helpers/ValidateForm';
import { NgToastService } from 'ng-angular-popup';
import { SuccessModalComponent } from '../../modal/success-modal/success-modal.component';
declare var window: any;

@Component({
  selector: 'app-a-route',
  templateUrl: './a-route.component.html',
  styleUrls: ['./a-route.component.css']
})
export class ARouteComponent implements OnInit {

  Routes: Array<any> = [];
  Stations: Array<any> = [];

  routeDetail: RouteInterface = {
    id: '',
    routeName: '',
    departureStationId: '',
    destinationStationId: '',
    routeFare: 0,
    description: '',
    createBy: '',
    createTime: new Date()
  };
  isLoadRoute: boolean = false;
  modalRef: any;

  editRouteForm!: FormGroup;
  addRouteForm!: FormGroup;

  constructor(
    private adminService: AdminService,
    private dataService: DataService,
    private routeService: RouteService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private toast: NgToastService
  ) { }

  testModal() {
    this.modalRef = this.modalService.open(SuccessModalComponent, 
      { windowClass: 'custom-modal' }
      )
  }
  ngOnInit(): void {
    this.receivedRoute();
    this.receivedStation();
  }

  receivedRoute() {
    this.dataService.receivedRoute$.subscribe((value) => {
      this.isLoadRoute = true;
      this.Routes = value;
      console.log(this.Routes);
    })
  }

  receivedStation() {
    this.dataService.receivedStation$.subscribe((value) => {
      this.Stations = value;
      console.log(this.Stations);
    })
  }

  showRouteDetail(detail: any, route: any) {
    console.log("Show route detail: ", route);
    this.routeDetail = route;
    this.initializeEditForm(this.routeDetail);
    this.modalRef = this.modalService.open(detail, { ariaLabelledBy: 'modal-basic-title' })
  }

  showAddRouteModal(detail: any) {
    this.addRouteForm = this.fb.group({
      RouteName: ['', Validators.required],
      DepartureStation: ['', Validators.required],
      DestinationStation: ['', Validators.required],
      RouteFare: ['', Validators.required],
      Description: [''],
      CreateBy: [null],
      CreateTime: new Date()
    })
    this.modalRef = this.modalService.open(detail, { ariaLabelledBy: 'modal-basic-title' })
  }

  initializeEditForm(routeDetail: any) {
    this.editRouteForm = this.fb.group({
      Id: [routeDetail.id],
      RouteName: [routeDetail.routeName, Validators.required],
      DepartureStation: [routeDetail.departureStationId, Validators.required],
      DestinationStation: [routeDetail.destinationStationId, Validators.required],
      RouteFare: [routeDetail.routeFare, Validators.required],
      Description: [routeDetail.description],
      updateBy: [null],
      updateTime: new Date()
    })
  }

  selectDepartureStation(event: any) {
    const value = event.target.value;
    this.editRouteForm.patchValue({
      DepartureStation: value
    });
  }

  selectDestinationStation(event: any) {
    const value = event.target.value;
    this.editRouteForm.patchValue({
      DestinationStation: value
    });
  }

  resetAddForm() {
    this.addRouteForm.reset();
  }

  resetEditForm() {
    this.editRouteForm.reset();
    this.initializeEditForm(this.routeDetail);
  }

  addRoute() {
    if (this.addRouteForm.valid) { 
      console.log("form valid: ", this.addRouteForm.value);
      this.routeService.addRoute(this.addRouteForm.value)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.toast.success({ detail: "Success", summary: "Add new route success", duration: 5000,  position:'topCenter' });
            this.modalRef = this.modalService.dismissAll();
            this.routeService.reloadRoute();
            this.receivedRoute();
          },
          error: (err) => {
            console.error(err?.error);
            this.toast.error({ detail: "Error", summary: "Something when wrong", duration: 5000,  position:'topCenter' });
          }
        })
    } else {
      console.log("form is invalid", this.addRouteForm.value);
      ValidateForm.validateFormFields(this.addRouteForm);
    }
  }

  editRoute() {
    if (this.editRouteForm.valid) {
      // this.toast.success({ detail: "Success", summary: "Update infomation success", duration: 5000, sticky: true,  position:'topCenter' });
      console.log(this.editRouteForm.value);

      this.routeService.updateRoute(this.editRouteForm.value)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.toast.success({ detail: "Success", summary: "Update infomation success", duration: 5000,  position:'topCenter' });
            this.modalRef = this.modalService.dismissAll();
            this.routeService.reloadRoute();
            this.receivedRoute();
          },
          error: (err) => {
            console.error(err?.error);
            this.toast.error({ detail: "Error", summary: "Something when wrong", duration: 5000,  position:'topCenter' });
          }
        })
    } else {
      console.log("form is invalid", this.editRouteForm.value);

      ValidateForm.validateFormFields(this.editRouteForm);
    }
  }
}
