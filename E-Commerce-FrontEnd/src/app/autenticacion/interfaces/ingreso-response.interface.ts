export interface LoginResponse {
    authResult: AuthResult;
}

export interface AuthResult {
    accessToken:  string;
    refreshToken: string;
    result:       boolean;
    statusCode:   number;
    mensajes:     Mensaje[];
}

export interface Mensaje {
    message: string;
    class:   string;
    type:    string;
}
