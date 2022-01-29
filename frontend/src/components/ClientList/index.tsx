import { useEffect, useState } from "react";
import { api } from "../../services/api";
import { Container, PhoneNumberContainer } from "./styles";

//[{client.phoneNumber[{number}]}]

interface ListProps {
  onOpenEditClientModal: () => void;
}

interface ClientNumber {
  id: number;
  number: string;
}

interface Client {
  id: number;
  cpf: string;
  cnpj: string;
  name: string;
  classification: string;
  phoneNumber: ClientNumber[];
}

export function ClientList({ onOpenEditClientModal }: ListProps) {
  const [clients, setClients] = useState<Client[]>([]);

  const [clientNumbers, setClientNumbers] = useState<ClientNumber[]>([]);

  useEffect(() => {
    api.get("/").then((response) => setClients(response.data));
  }, []);

  // clients.map((client) => {
  //   setClientNumbers(client.phoneNumber);
  // });

  console.log(clients);

  return (
    <Container>
      <table>
        <thead>
          <tr>
            <th>CPF/CNPJ</th>
            <th>Nome</th>
            <th>Classificação</th>
            <th>Telefones</th>
          </tr>
        </thead>

        <tbody>
          {clients.map((client) => {
            return (
              <tr key={client.id}>
                <td>
                  {client.cpf}/{client.cnpj}
                </td>
                <td>{client.name}</td>
                <td>{client.classification}</td>
                <PhoneNumberContainer>
                  {clientNumbers.map((phoneNumber) => {
                    return <p key={phoneNumber.id}>{client.phoneNumber}</p>;
                  })}
                </PhoneNumberContainer>
                <button onClick={onOpenEditClientModal}>Editar</button>
                <button
                  onClick={() => {
                    api
                      .delete(`/Delete?cpf=${client.cpf}`)
                      .then(() => alert("Cliente apagado"));
                  }}
                >
                  Deletar
                </button>
              </tr>
            );
          })}
        </tbody>
      </table>
    </Container>
  );
}
