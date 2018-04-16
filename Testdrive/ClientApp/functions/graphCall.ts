import { httpCall } from './httpCall';

export default function graphCall(body: { query: string }, success?: Function | undefined, error?: Function | undefined) {
    return httpCall(
        'graph',
        'post',
        body,
        (data: any) => data.json(),
        (err: any) => error ? error(err) : { error: "error occurred" }
    ).then(result => success ? success(result) : result);
}