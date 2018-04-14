import { httpCall } from './httpCall';

export function graphCall(body: { query: string }) {
	return httpCall(
		'graph',
		'post',
		body,
		(data: any) => data.json(),
		(error: any) => { console.log(error); return { error: 'Error running query against schema.' } }
	);
}

export function graphCallback(body: { query: string }, success: Function, error: Function) {
	return graphCall(body).then(data => data ? success(data) : error()).catch(err => error(err));
}
