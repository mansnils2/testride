import * as React from 'react';
import getCarInfo from '../../functions/getCarInfo';

type LocalState = {
	hasError: boolean,
	isLoading: boolean,
	buttonText: string,
	licenseplate: string,
	carName: string,
	message: string,
	disabled: boolean,
}

export class StartTestdrive extends React.Component<{}, LocalState> {
	constructor() {
		super();
		this.state = {
			hasError: false,
			isLoading: true,
			buttonText: 'Väntar ...',
			licenseplate: '',
			carName: '',
			message: 'Skriv in registreringsnummer.',
			disabled: true
		};

		this.reviewLicenseplate = this.reviewLicenseplate.bind(this);
		this.successfulApiCall = this.successfulApiCall.bind(this);
		this.errorInApiCall = this.errorInApiCall.bind(this);
	}

	reviewLicenseplate(event) {
		const value = event.target.value;
		
		if (value.length <= 6) this.setState({ licenseplate: value });
		if (value.length === 6) getCarInfo(value, this.successfulApiCall, this.errorInApiCall);
	}

	successfulApiCall(result) {
		result.then(info => {
				const basic = info.data.basic.data;
				const name = basic.make + ' ' + basic.model;

				const lp = this.state.licenseplate.toUpperCase();
				const text = `Provkör ${lp}`;

				this.setState({
					carName: name,
					buttonText: text,
					disabled: false,
					hasError: false,
					message: `Registrera provkörning för ${lp + ' - ' + name}!`
				});
			})
			.catch(_ => this.errorInApiCall());
	}

	errorInApiCall() {
		this.setState({ hasError: true, message: 'Det verkar inte gå att hitta någon data på det registreringsnumret.' });
	}

	addTestdrive() {
		const mutation =
			`mutation {
				addTestdrive(licenseplate: "${this.state.licenseplate}", carName: "${this.state.carName}")
			}`;

	}



	render() {
		return <div className="row" style={{ 'height': '380px' }}>
			       <div className="bg-dark w-100 position-relative">
				       <div className="card m-auto absolute-centered w-100" style={{ 'maxWidth': '290px' }}>
					       <div className="card-body p-3">
						       <div className={`alert alert-${this.state.hasError ? 'danger' : 'primary'}`}>
							       <p className="text-center mb-0">{this.state.message}</p>
						       </div>
						       <input className="form-control text-center text-uppercase" placeholder="PMX732" value={this.state.licenseplate} onChange={this.reviewLicenseplate}/>
						       <button className="btn btn-primary mt-3 w-100" disabled={this.state.disabled}>{this.state.buttonText
						       }</button>
					       </div>
				       </div>
			       </div>
		       </div>;
	}
}