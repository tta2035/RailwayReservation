export interface RouteInterface {
    id: string,
    routeName: string,
    departureStationId: string,
    destinationStationId: string,
    routeFare: number,
    description: string,
    createBy: string,
    createTime: Date
}