import { useDispatch, useSelector } from 'react-redux';
import './index.scss';
import type { IStorState } from '../../types';
import { useEffect } from 'react';
import { loadClients } from '../../redux/action-creators';

export const Clients = () => {
    const clients = useSelector((state: IStorState) => state.dashboard.clients)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(loadClients())
    }, [])
    return (
        <div className="table-container">
            <h3 className="table-caption">Clients</h3>
            <table className="styled-table">
                <thead>
                    <tr>
                    <th>email</th>
                    <th>name</th>
                    <th>balance</th>
                    </tr>
                </thead>
                <tbody>
                    {clients.map((item) => (
                    <tr key={item.id}>
                        <td>{item.email}</td>
                        <td>{item.name}</td>
                        <td>{item.balance}</td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}