import createSagaMiddleware from "redux-saga";
import { watcherDashboard, watcherUsers } from "./action-creators";
import { all } from "redux-saga/effects";
import { applyMiddleware, combineReducers, createStore } from "redux";
import { dashboardReducer, userReducer } from "./reducers";

const middleware = createSagaMiddleware();

function* rootSaga() {
    yield all([
        watcherUsers(),
        watcherDashboard()
    ])
}

export const store = createStore(combineReducers({
    user: userReducer,
    dashboard: dashboardReducer
}), {},
applyMiddleware(middleware))

middleware.run(rootSaga);