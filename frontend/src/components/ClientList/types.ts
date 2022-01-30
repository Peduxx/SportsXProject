export interface ClientNumber {
  id?: number;
  number: string;
}

export interface Client {
  id: number;
  cpf: string;
  cnpj: string;
  cep: string;
  email: string;
  socialReason: string;
  name: string;
  classification: number;
  phoneNumber: ClientNumber[];
}
