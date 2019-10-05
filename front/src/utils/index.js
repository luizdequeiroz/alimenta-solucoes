/**
 * Formatar a data
 */
export function formatDate(dateTime) {
    if (dateTime) {
        const date = new Date(dateTime);
        date.setDate(date.getDate() + 1);
        return date.toLocaleDateString();
    }
    return '-';
}

export const API_DOTNET = process.env.REACT_APP_API_DEVELOP_NET