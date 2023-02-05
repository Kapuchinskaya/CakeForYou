import { Box, Menu, MenuItem, Typography } from "@mui/material";
import { t } from "i18next";
import React, { useEffect, useState } from "react";
import NavBarIconButton from "./navBarIconButton";
import MenuIcon from "@mui/icons-material/Menu";
import { useTranslation } from "react-i18next";

interface NavBarMenuForSmallScreens {
  pages: string[];
  onHoverColor: string;
}

const NavBarMenuForSmallScreens = ({
  pages,
  onHoverColor,
}: NavBarMenuForSmallScreens): JSX.Element => {
  const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);

  //handlers
  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  //translation
  const { t, i18n } = useTranslation();

  useEffect(() => {
    const lng = navigator.language;
    i18n.changeLanguage(lng);
  }, []);

  return (
    <Box
      sx={{
        flexGrow: 1,
        display: { xs: "flex", md: "none" },
        justifyContent: "flex-end",
      }}
    >
      <NavBarIconButton
        iconSize="medium"
        onHoverColor={onHoverColor}
        onClickFunction={handleOpenNavMenu}
        child={<MenuIcon />}
      />
      <Menu
        anchorEl={anchorElNav}
        anchorOrigin={{
          vertical: "bottom",
          horizontal: "left",
        }}
        keepMounted
        transformOrigin={{
          vertical: "top",
          horizontal: "left",
        }}
        open={Boolean(anchorElNav)}
        onClose={handleCloseNavMenu}
        sx={{
          display: { xs: "block", md: "none" },
        }}
      >
        {pages.map((page) => (
          <MenuItem key={page} onClick={handleCloseNavMenu}>
            <Typography>{t(`pages.${page}`)}</Typography>
          </MenuItem>
        ))}
      </Menu>
    </Box>
  );
};

export default NavBarMenuForSmallScreens;
