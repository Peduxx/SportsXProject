import styled from "styled-components";

export const PhoneNumberContainer = styled.td``;

export const Container = styled.div`
  padding: 1rem;
  display: flex;
  justify-content: center;
  padding: 0;

  font-family: sans-serif;

  button {
    margin: 5px;
    display: grid;
  }

  table {
    width: 80%;
    border-spacing: 0 0.5rem;

    th {
      color: var(--text-body);
      font-weight: 400;
      padding: 1rem 2rem;
      text-align: left;
      line-height: 1.5rem;
    }

    td {
      color: var(--text-title);
      background-color: var(--shape);
      border: 0;
      padding: 1rem 2rem;
      text-align: left;
      line-height: 1.5rem;
      border-radius: 0.5rem;
    }
  }
`;
