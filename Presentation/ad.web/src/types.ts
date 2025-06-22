export interface IClient {
    id: string,
    email: string,
    name: string,
    balance: string
}

export interface IRate {
    id: string,
    dateSet: string,
    currentRate: string
}

export interface IPayment {
    id: string,
    dateTime: string,
    amount: string,
    rate: string,
    userName: string,
    userEmail: string
}

export interface IAuthResponse {
    token: string,
    refreshToken: string
}

export interface IUserState {

}

export interface IDashboardState {
    clients: IClient[],
    rate: IRate,
    payments: IPayment[]
}

export interface IStorState {
    dashboard: IDashboardState,
    user: IUserState
}