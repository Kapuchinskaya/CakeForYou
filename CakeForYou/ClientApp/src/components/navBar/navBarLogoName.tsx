import { Box, Typography } from "@mui/material";
import React, { useEffect } from "react";
import CakeIcon from "@mui/icons-material/Cake";
import NavBarIconButton from "./navBarIconButton";
import { useTranslation } from "react-i18next";

interface NavBarLogoName {
  onHoverColor: string;
}

const NavBarLogoName = ({ onHoverColor }: NavBarLogoName): JSX.Element => {
  //translation
  const { t, i18n } = useTranslation();

  useEffect(() => {
    const lng = navigator.language;
    i18n.changeLanguage(lng);
  }, []);

  return (
    <Box
      sx={{
        display: { xs: "flex", md: "flex" },
        alignItems: "center",
      }}
    >
      <NavBarIconButton
        iconSize="large"
        iconLink="/"
        onHoverColor={onHoverColor}
        // TODO delete cl function
        onClickFunction={() => console.log("clicked")}
        child={<CakeIcon />}
      />
      <Typography
        variant="h5"
        noWrap
        component="a"
        href="/"
        sx={{
          display: { xs: "none", sm: "block" },
          mr: 2,
          fontFamily: "monospace",
          fontWeight: 700,
          letterSpacing: ".3rem",
          color: "inherit",
          textDecoration: "none",
          underline: "none",
        }}
      >
        {t("navBar.companyName")}
      </Typography>
    </Box>
  );
};

export default NavBarLogoName;
