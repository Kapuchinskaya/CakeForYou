import { AppBar, Container, Toolbar } from "@mui/material";
import React from "react";
import NavBarMenu from "./navBarMenu";
import NavBarLogoName from "./navBarLogoName";
import NavBarMenuForSmallScreens from "./navBarMenuForSmallScreens";

const pages = ["page1", "page2", "page3", "page4", "pageShoppingCart"];

const style = {
  mainColor: "#f2ebf2",
  onHoverColor: "#8c686c",
  textColorHeaders: "#af8288",
};

const NavBar = (): JSX.Element => {
  return (
    <AppBar
      position="static"
      elevation={0}
      sx={{ bgcolor: style.mainColor, color: style.textColorHeaders }}
    >
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          {/*toolbar - logo and name */}
          <NavBarLogoName onHoverColor={style.onHoverColor} />
          {/*toolbar -  menu with pages for a large screen*/}
          <NavBarMenu
            pages={pages}
            textColorHeaders={style.textColorHeaders}
            onHoverColor={style.onHoverColor}
          />
          {/*toolbar -  menu icon */}
          <NavBarMenuForSmallScreens
            pages={pages}
            onHoverColor={style.onHoverColor}
          />
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default NavBar;
