import { createGlobalStyle } from "styled-components";

export const GlobalStyle = createGlobalStyle`

    :root {
        --red: #E52B4D;
        --blue: #3A4DC3;

        --blue-light: #6933FF;

        --text-title: #363F5F;
        --text-body: #969CB3;

        --background: #f0f2f5;
        --shape: #FFFFFF;
    }

  *{
      margin: 0;
      padding: 0;
      box-sizing: border-box;
  }

  html {
      @media(max-width: 1080px){
          font-size: 93.75px;
      }

      @media(max-width: 720px){
          font-size: 87.5%;
      }
  }

  body{
    background: var(--background);
    -webkit-font-smoothing: antialiased;
  }

  button{
      cursor: pointer;
  }

  [disabled]{
      opacity:0.6;
      cursor: not-allowed;
  }

  .react-modal-overlay{
    background: rgba(0, 0, 0, 0.5);

    position: fixed;
    top: 0;
    right: 0;
    left: 0;
    bottom: 0;

    display: flex;
    align-items: center;
    justify-content: center;
  }

  .react-modal-content{
    width: 100%;
    max-width: 576px;

    background: var(--background);

    padding: 3rem;
    position: relative;
    border-radius: 0.5rem;
  }
`;
