import { Clients } from '../Clients';
import { Payments } from '../Payments';
import { Rate } from '../Rate';
import './index.scss';

export const Dashboard = () => {
    return (
        <>
            <Clients/>
            <Payments/>
            <Rate/>
        </>
    )
}