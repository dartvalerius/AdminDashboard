import { call, put, takeEvery } from "redux-saga/effects";
import type { IClient, IPayment, IRate } from "../../types";
import { LOAD_CLIENTS, LOAD_PAYMENTS, LOAD_RATE, SET_CLIENTS, SET_PAYMENTS, SET_RATE, UPDATE_RATE } from "../action-types";

export const setClients = (clients: IClient[]) => ({
    type: SET_CLIENTS,
    clients
})

export const loadClients = () => ({
    type: LOAD_CLIENTS
})

export const setRate = (rate: IRate) => ({
    type: SET_RATE,
    rate
})

export const loadRate = () => ({
    type: LOAD_RATE
})

export const updateRate = (newRate: number) => ({
    type: UPDATE_RATE,
    newRate
})

export const setPayments = (payments: IPayment[]) => ({
    type: SET_PAYMENTS,
    payments
})

export const loadPayments = (take: number) => ({
    type: LOAD_PAYMENTS,
    take
})

function* fetchLoadClients(action: any) {
    const fetchString = 'http://localhost:5070/clients';
    const response: Response = yield fetch(fetchString);
    if (response.status === 200) {
        const { clients } : {clients: IClient[]} = yield response.json();
        yield put(setClients(clients)); 
    }
    else {
        const error: string = yield response.json()
        console.error(error)
    }
}

function* fetchLoadRate(action: any) {
    const fetchString = 'http://localhost:5070/rate';
    const response: Response = yield fetch(fetchString);
    if (response.status === 200) {
        const rate : IRate = yield response.json();
        yield put(setRate(rate));
    }
    else {
        const error: string = yield response.json()
        console.error(error)
    }
}

function* fetchUpdateRate(action: any) {
    const fetchString = 'http://localhost:5070/rate';
    const response: Response = yield fetch(fetchString, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({rate: action.newRate})
    });
    if (response.status === 201) {
        yield call(fetchLoadRate, {})
    }
    else {
        const error: string = yield response.json()
        console.error(error)
    }
}

function* fetchLoadPayments(action: any) {

    const fetchString = `http://localhost:5070/payments?take=${action.take}`;
    const response: Response = yield fetch(fetchString);
    if (response.status === 200) {
        const { payments } : {payments: IPayment[]} = yield response.json();
        yield put(setPayments(payments)); 
    }
    else {
        const error: string = yield response.json()
        console.error(error)
    }
}

export function* watcherDashboard() {
    yield takeEvery(LOAD_CLIENTS, fetchLoadClients);
    yield takeEvery(LOAD_RATE, fetchLoadRate);
    yield takeEvery(UPDATE_RATE, fetchUpdateRate);
    yield takeEvery(LOAD_PAYMENTS, fetchLoadPayments);
}