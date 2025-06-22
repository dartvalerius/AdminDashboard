import { useDispatch, useSelector } from 'react-redux';
import type { IStorState } from '../../types';
import './index.scss';
import { useEffect, useState } from 'react';
import { loadRate, updateRate } from '../../redux/action-creators';

export const Rate = () => {
    const [newRate, setNewRate] = useState('');
    const rate = useSelector((state: IStorState) => state.dashboard.rate)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(loadRate())
    }, [])

    const handleUpdate = (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        if (newRate) {
            dispatch(updateRate(+newRate));
            setNewRate('');
        }
    };
    return (
        <div className='container'>
            <h3 className='title'>Current Rate</h3>
            <div className='currentRate'>{rate.currentRate}</div>
            
            <div className='inputGroup'>
                <input
                    type="number"
                    className='input'
                    placeholder="Enter new rate"
                    value={newRate}
                    onChange={(e) => setNewRate(e.target.value)}
                />
                <button 
                    className='button'
                    onClick={handleUpdate}
                    disabled={!newRate}
                >
                    Update
                </button>
            </div>
        </div>
    )
}