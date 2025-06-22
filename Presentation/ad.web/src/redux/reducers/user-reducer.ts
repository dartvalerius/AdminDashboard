import type { IUserState } from "../../types"
import { SET_USER } from "../action-types"

const initialState = {

}

export const userReducer = (state: IUserState = initialState, action: any) => {
    switch(action.type) {
        case SET_USER: {
            localStorage.setItem('token', action.authResponse.token)
            localStorage.setItem('refreshToken', action.authResponse.refreshToken)
            return ({
                ...state
            })
        }
        default: return state;
    }
}