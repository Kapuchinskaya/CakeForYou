import { ShoppingCart } from "@mui/icons-material";
import { Box, Button, IconButton, Tooltip } from "@mui/material";
import React, { useEffect } from "react";
import { useTranslation } from "react-i18next";

interface NavBarMenu {
  pages: string[];
  textColorHeaders: string;
  onHoverColor: string;
}

const NavBarMenu = ({
  pages,
  textColorHeaders,
  onHoverColor,
}: NavBarMenu): JSX.Element => {
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
        display: { xs: "none", md: "flex" },
        justifyContent: "flex-end",
      }}
    >
      {pages.map((page) =>
        page !== "pageShoppingCart" ? (
          <Button
            key={page}
            sx={{
              fontWeight: "bold",
              my: 2,
              display: "block",
              color: textColorHeaders,
              "&:hover": {
                color: onHoverColor,
                backgroundColor: "rgba(0, 0, 0, 0)",
              },
            }}
          >
            {t(`pages.${page}`)}
          </Button>
        ) : (
          <Tooltip title="Shopping Cart" key={page}>
            <IconButton
              sx={{
                color: textColorHeaders,
                my: 2,
                "&:hover": {
                  color: onHoverColor,
                  backgroundColor: "rgba(0, 0, 0, 0)",
                },
              }}
            >
              <ShoppingCart />
            </IconButton>
          </Tooltip>
        )
      )}
    </Box>
  );
};

export default NavBarMenu;
