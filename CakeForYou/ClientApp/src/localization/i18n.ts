import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";

i18n
  // detect user language
  // learn more: https://github.com/i18next/i18next-browser-languageDetector
  .use(LanguageDetector)
  // pass the i18n instance to react-i18next.
  .use(initReactI18next)
  // init i18next
  // for all options read: https://www.i18next.com/overview/configuration-options
  .init({
    debug: true,
    fallbackLng: "en",
    interpolation: {
      escapeValue: false, // not needed for react as it escapes by default
    },
    resources: {
      en: {
        translation: {
          navBar: {
            companyName: "Cheesecake Factory",
          },
          pages: {
            page1: "About Us",
            page2: "Our cakes",
            page3: "Make a cake",
            page4: "Contact us",
            pageShoppingCart: "Shopping Cart",
          },
        },
      },
      ru: {
        translation: {
          navBar: {
            companyName: "Сырники у тёти Глаши",
          },
          pages: {
            page1: "О нас",
            page2: "Торты",
            page3: "Собери свой торт",
            page4: "Связаться с нами",
            page5: "Корзина",
          },
        },
      },
      pl: {
        translation: {
          navBar: {
            companyName: "Kokao-kletoczka",
          },
          pages: {
            page1: "About Us",
            page2: "Our cakes",
            page3: "Make a cake",
            page4: "Contact us",
            page5: "Shopping Cart",
          },
        },
      },
    },
  });

export default i18n;
