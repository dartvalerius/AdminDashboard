import type { IClient, IDashboardState, IPayment, IRate } from "../../types";
import { SET_CLIENTS, SET_PAYMENTS, SET_RATE } from "../action-types";

const initialState = {
    clients: [] as IClient[],
    rate: {} as IRate,
    payments: [] as IPayment[]
}

export const dashboardReducer = (state: IDashboardState = initialState, action: any) => {
    switch(action.type) {
        case SET_CLIENTS: {
            return ({
                ...state,
                clients: action.clients
            })
        }
        case SET_RATE: {
            return ({
                ...state,
                rate: action.rate
            })
        }
        case SET_PAYMENTS: {
            return({
                ...state,
                payments: action.payments
            })
        }
        default: return state;
    }
}