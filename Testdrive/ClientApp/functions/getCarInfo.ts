function getCarInfoCredentials() {
	return fetch('credentials/car-info',
		{
			credentials: 'include'
		}).then(response => response.json())
		.catch(_ => undefined);
}

export default function getCarInfo(licenseplate: string, success: Function, error: Function) {
	getCarInfoCredentials().then(creds => {
		return fetch(creds.url + licenseplate + '?api_token=' + creds.token)
			.then(response => success(response.json()))
			.catch(_ => error());
	}).catch(_ => error());
}