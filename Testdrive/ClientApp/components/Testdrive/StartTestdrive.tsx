import * as React from 'react';

export const StartTestdrive = () => {
    return <div className="row" style={{ 'height': '300px' }}>
        <div className="bg-dark w-100 position-relative">
            <div className="card m-auto absolute-centered w-100" style={{'maxWidth':'290px'}}>
                <div className="card-body p-3">
                    <div className="alert alert-info">
                        <p className="text-center mb-0">Skriv in registreringsnummer.</p>
                    </div>
                    <input className="form-control text-center text-capitalize" placeholder="ABC123" />
                    <button className="btn btn-primary mt-3 w-100">Starta!</button>
                </div>
            </div>
        </div>
    </div>;
}