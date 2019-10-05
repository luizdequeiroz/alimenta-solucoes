export function setValue(key, value) {
    return {
        type: 'set_value',
        payload: { key, value }
    };
}

export function clearValues() {
    return { type: 'clear_values' };
}

const proccess = {
    icon: 'fa fa-cog fa-2x fa-spin fa-fw',
    className: 'alert-primary',
    message: 'Processando, aguarde.',
    show: true
};

const finish = {
    icon: '',
    className: '',
    message: '',
    show: false
};


const request = (method, endpoint, returnReduceKey, param, treatment, callback, api) => (
    [
        setValue('loading', proccess),
        {
            type: 'request',
            request: {
                api,
                method,
                endpoint,
                returnReduceKey,
                param,
                treatment
            },
            callback: [
                setValue('loading', finish),
                callback
            ]
        }
    ]
);

export function post(endpoint, returnReduceKey, { param, treatment, callback, api } = {}) {
    return request('POST', endpoint, returnReduceKey, param, treatment, callback, api)
}

export function put(endpoint, returnReduceKey, { param, treatment, callback, api } = {}) {
    return request('PUT', endpoint, returnReduceKey, param, treatment, callback, api)
}

export function get(endpoint, returnReduceKey, { treatment, callback, api } = {}) {
    return request('GET', endpoint, returnReduceKey, undefined, treatment, callback, api)
}

export function del(endpoint, returnReduceKey, { treatment, callback, api } = {}) {
    return request('DELETE', endpoint, returnReduceKey, undefined, treatment, callback, api)
}

export function dispatch({ type, payload }) {
    return { type, payload };
}