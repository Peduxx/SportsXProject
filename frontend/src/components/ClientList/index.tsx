import PhoneNumber from "./PhoneNumber";
import { Container } from "./styles";
import { Client } from "./types";
import { api } from "../../services/api";
import { toast } from "react-toastify";

interface ListProps {
  onOpenEditClientModal: () => void;
  setClientToEdit: any;
  clients: Client[];
  clientCPFFilter: string;
}

export function ClientList({
  onOpenEditClientModal,
  clients,
  clientCPFFilter,
  setClientToEdit,
}: ListProps) {
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
          {clients
            ?.filter((client: Client) => client.cpf.includes(clientCPFFilter))
            .map((clientFiltered: Client) => {
              return (
                <tr key={clientFiltered.id}>
                  <td>
                    {clientFiltered.cpf}/{clientFiltered.cnpj}
                  </td>
                  <td>{clientFiltered.name}</td>
                  <td>
                    {clientFiltered.classification === 1
                      ? "Ativo"
                      : clientFiltered.classification === 2
                      ? "Inativo"
                      : "Preferencial"}
                  </td>

                  <PhoneNumber numbers={clientFiltered?.phoneNumber} />

                  <div className="buttons">
                    <button
                      className="edit-button"
                      onClick={() => {
                        onOpenEditClientModal();
                        setClientToEdit(clientFiltered);
                      }}
                    >
                      Editar
                    </button>

                    <button
                      className="delete-button"
                      onClick={async () => {
                        await api.delete(`/Delete?cpf=${clientFiltered.cpf}`);

                        try {
                          toast.success("Cliente deletado com sucesso!");

                          window.location.reload();
                        } catch (err) {
                          toast.error("Erro ao tentar deletar o usuário.");
                        }
                      }}
                    >
                      Deletar
                    </button>
                  </div>
                </tr>
              );
            })}
        </tbody>
      </table>
    </Container>
  );
}
