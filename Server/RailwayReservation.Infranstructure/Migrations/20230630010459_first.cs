using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayReservation.Infranstructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    PassengerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(type: "date", nullable: false),
                    Genger = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "SeatType",
                columns: table => new
                {
                    SeatTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RaitoFare = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType", x => x.SeatTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.TrainID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "GroupFunction",
                columns: table => new
                {
                    GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFunction", x => new { x.GroupID, x.FunctionID });
                    table.ForeignKey(
                        name: "FK_GroupFunction_Function",
                        column: x => x.FunctionID,
                        principalTable: "Function",
                        principalColumn: "FunctionID");
                    table.ForeignKey(
                        name: "FK_GroupFunction_Group",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "BankingPassenger",
                columns: table => new
                {
                    BankingPassengerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingPassenger", x => x.BankingPassengerID);
                    table.ForeignKey(
                        name: "FK_BankingPassenger_Passenger",
                        column: x => x.PassengerID,
                        principalTable: "Passenger",
                        principalColumn: "PassengerID");
                    table.ForeignKey(
                        name: "FK_BankingPassenger_PaymentMethod1",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodID");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartureStation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationStation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteFare = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Route_Destination_Station",
                        column: x => x.DestinationStation,
                        principalTable: "Station",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK_Route_Station",
                        column: x => x.DepartureStation,
                        principalTable: "Station",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachID);
                    table.ForeignKey(
                        name: "FK_Coach_Train",
                        column: x => x.TrainID,
                        principalTable: "Train",
                        principalColumn: "TrainID");
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupID, x.UserID });
                    table.ForeignKey(
                        name: "FK_GroupUser_Group",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK_GroupUser_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalFare = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentTerm = table.Column<DateTime>(type: "datetime", nullable: false),
                    DefaultPaymentMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PassengerPaymentMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancellationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancellationFee = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_BankingPassenger",
                        column: x => x.PassengerPaymentMethod,
                        principalTable: "BankingPassenger",
                        principalColumn: "BankingPassengerID");
                    table.ForeignKey(
                        name: "FK_Booking_Passenger",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "PassengerID");
                    table.ForeignKey(
                        name: "FK_Booking_PaymentMethod",
                        column: x => x.DefaultPaymentMethod,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodID");
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatID);
                    table.ForeignKey(
                        name: "FK_Seat_Coach",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "CoachID");
                    table.ForeignKey(
                        name: "FK_Seat_SeatType",
                        column: x => x.SeatTypeID,
                        principalTable: "SeatType",
                        principalColumn: "SeatTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Paid",
                columns: table => new
                {
                    PaidID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paid", x => x.PaidID);
                    table.ForeignKey(
                        name: "FK_Paid_Booking",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "Refund",
                columns: table => new
                {
                    RefundID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RefundTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refund", x => x.RefundID);
                    table.ForeignKey(
                        name: "FK_Refund_Booking",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ArriveTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Route",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "RouteID");
                    table.ForeignKey(
                        name: "FK_Ticket_Seat",
                        column: x => x.SeatID,
                        principalTable: "Seat",
                        principalColumn: "SeatID");
                    table.ForeignKey(
                        name: "FK_Ticket_Train",
                        column: x => x.TrainID,
                        principalTable: "Train",
                        principalColumn: "TrainID");
                });

            migrationBuilder.CreateTable(
                name: "BookingTicket",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTicket", x => new { x.BookingID, x.TicketID });
                    table.ForeignKey(
                        name: "FK_BookingTicket_Booking",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK_BookingTicket_Ticket",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankingPassenger_1",
                table: "BankingPassenger",
                column: "BankAccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankingPassenger_PassengerID",
                table: "BankingPassenger",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_BankingPassenger_PaymentMethodID",
                table: "BankingPassenger",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DefaultPaymentMethod",
                table: "Booking",
                column: "DefaultPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PassengerId",
                table: "Booking",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PassengerPaymentMethod",
                table: "Booking",
                column: "PassengerPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_TicketID",
                table: "BookingTicket",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Coach",
                table: "Coach",
                column: "CoachNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TrainID",
                table: "Coach",
                column: "TrainID");

            migrationBuilder.CreateIndex(
                name: "IX_Function_1",
                table: "Function",
                column: "FunctionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_1",
                table: "Group",
                column: "GroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupFunction_FunctionID",
                table: "GroupFunction",
                column: "FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserID",
                table: "GroupUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Paid_BookingID",
                table: "Paid",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_1",
                table: "Passenger",
                columns: new[] { "Email", "PhoneNo" },
                unique: true,
                filter: "[PhoneNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_1",
                table: "PaymentMethod",
                column: "PaymentMethodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refund_BookingID",
                table: "Refund",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_1",
                table: "Route",
                column: "RouteName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_DepartureStation",
                table: "Route",
                column: "DepartureStation");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationStation",
                table: "Route",
                column: "DestinationStation");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_1",
                table: "Seat",
                column: "SeatNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_CoachID",
                table: "Seat",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatTypeID",
                table: "Seat",
                column: "SeatTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatType_1",
                table: "SeatType",
                column: "SeatTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Station_1",
                table: "Station",
                column: "StationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RouteID",
                table: "Ticket",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatID",
                table: "Ticket",
                column: "SeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TrainID",
                table: "Ticket",
                column: "TrainID");

            migrationBuilder.CreateIndex(
                name: "IX_Train_1",
                table: "Train",
                column: "TrainName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_1",
                table: "User",
                columns: new[] { "Email", "UserName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTicket");

            migrationBuilder.DropTable(
                name: "GroupFunction");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Paid");

            migrationBuilder.DropTable(
                name: "Refund");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "BankingPassenger");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "SeatType");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
