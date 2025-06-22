import { put, takeEvery } from "redux-saga/effects";
import type { IAuthResponse } from "../../types";
import { AUTHENTICATION, SET_USER } from "../action-types";

export const setUser = (authResponse: IAuthResponse) => ({
    type: SET_USER,
    authResponse
})

export const authentication = (dto: {email: string, password: string}) => ({
    type: AUTHENTICATION,
    dto
})

function* fetchAuthentication(action: any) {
    const fetchString = 'http://localhost:5070/auth/login';
    const {dto} = action;
    const response: Response = yield fetch(fetchString, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    })
    
    if (response.status === 200) {
        const data : IAuthResponse = yield response.json();
        yield put(setUser(data))
    }
    else {
        const error: string = yield response.json()
        localStorage.removeItem('token');
        localStorage.removeItem('refreshToken');
        console.error(error)
    }
}

export function* watcherUsers() {
    yield takeEvery(AUTHENTICATION, fetchAuthentication);
}