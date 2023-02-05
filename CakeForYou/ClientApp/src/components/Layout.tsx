import * as React from "react";
import { Container } from "reactstrap";
import NavBar from "./navBar/NavBar";
import WelcomePage from "./welcomePage.tsx/WelcomePage";

export default class Layout extends React.PureComponent<
  {},
  { children?: React.ReactNode }
> {
  public render() {
    return (
      <React.Fragment>
        <NavBar />
        <WelcomePage />
        <Container>{this.props.children}</Container>
      </React.Fragment>
    );
  }
}
