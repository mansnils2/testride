﻿export function httpCall(url: string, method = 'get', body: any, successCallback: Function, errorCallback: Function) {
    return fetch(url,
            {
                method: method,
                body: JSON.stringify(body),
                headers: {
                    "Content-Type": 'application/json'
                },
                credentials: 'include'
            }).catch(error => errorCallback(error))
        .then(response => successCallback(response));
}