import { useDispatch, useSelector } from 'react-redux';
import './index.scss';
import type { IStorState } from '../../types';
import { useEffect } from 'react';
import { loadPayments } from '../../redux/action-creators';

export const Payments = () => {
    const payments = useSelector((state: IStorState) => state.dashboard.payments)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(loadPayments(5))
    }, [])
    return (
        <div className="table-container">
            <h3 className="table-caption">Payments</h3>
            <table className="styled-table">
                <thead>
                    <tr>
                    <th>dateTime</th>
                    <th>amount</th>
                    <th>rate</th>
                    <th>userName</th>
                    <th>userEmail</th>
                    </tr>
                </thead>
                <tbody>
                    {payments.map((item) => (
                    <tr key={item.id}>
                        <td>{item.dateTime}</td>
                        <td>{item.amount}</td>
                        <td>{item.rate}</td>
                        <td>{item.userName}</td>
                        <td>{item.userEmail}</td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}