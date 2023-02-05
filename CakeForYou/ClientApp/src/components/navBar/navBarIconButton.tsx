import { IconButton } from "@mui/material";
import React from "react";

interface NavBarIconButton {
  // TODO Anton, какие типы данных мб у линка
  iconSize: any;
  iconLink?: any;
  onHoverColor: string;
  onClickFunction: (event: React.MouseEvent<HTMLElement>) => void;
  child: JSX.Element;
}

const NavBarIconButton = ({
  iconSize,
  iconLink,
  onHoverColor,
  onClickFunction,
  child,
}: NavBarIconButton): JSX.Element => {
  return (
    <IconButton
      size={iconSize}
      href={iconLink}
      aria-haspopup="true"
      onClick={onClickFunction}
      color="inherit"
      sx={{
        "&:hover": {
          color: onHoverColor,
          backgroundColor: "rgba(0, 0, 0, 0)",
        },
      }}
    >
      {child}
    </IconButton>
  );
};

export default NavBarIconButton;
