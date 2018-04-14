export function httpCall(url: string, method = 'get', body: any, successCallback: Function, errorCallback: Function) {
	return fetch(url,
		{
			method: method,
			body: JSON.stringify(body),
			headers: {
				"Content-Type": 'application/json'
			},
			
		}).then(response => successCallback(response))
		.catch(error => errorCallback(error));
}