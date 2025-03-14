#!/bin/bash

ASEPRITE_PATH="Aseprite"
FACE_BUTTONS_PATH="../FaceButtons.aseprite"
DIRECTIONAL_BUTTONS_PATH="../DirectionalButtons.aseprite"
THUMBSTICKS_PATH="../Thumbsticks.aseprite"
SYSTEM_BUTTONS_PATH="../SystemButtons.aseprite"
TOUCHPAD_PATH="../Touchpad.aseprite"
ICONS_PATH="../Icons.aseprite"
INDICATORS_PATH="../Indicators.aseprite"
CONTROLLER_PATH="../Controller.aseprite"
CONTROLLER_DIAGRAMS_PATH="../ControllerDiagrams.aseprite"
CARTRIDGE_PATH="../Cartridge.aseprite"
CONSOLE_PATH="../Console.aseprite"
SPLASH_PATH="../Splash.aseprite"
TV_PATH="../TV.aseprite"
LOGOS_PATH="../Logos.aseprite"
EXPORT_FOLDER_TAG_COMBINATIONS="./ExportFolderTagCombinations.lua"
EXPORT_TAGS="./ExportTags.lua"
EXPORT_SLICES="./ExportSlices.lua"
EXPORT_SHEET="./ExportSheet.lua"
SPRITES_FOLDER="../../Sprites/"
PARAMS="--script-param sprites-folder=$SPRITES_FOLDER"

display_menu() {
  echo "Please choose an option:"
  echo "1. Face Buttons"
  echo "2. Directional Buttons"
  echo "3. System Buttons"
  echo "4. Console & Cartridge"
  echo "5. Controller & Diagrams"
  echo "6. Indicators"
  echo "7. Icons"
  echo "8. TV, Logos & Splash Screen"
  echo "9. All"
  echo "10. Exit"
}

export_face_buttons() {
  echo "Exporting Face Buttons"
  "$ASEPRITE_PATH" -b "$FACE_BUTTONS_PATH" $PARAMS --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_console() {
  echo "Exporting Console"
  "$ASEPRITE_PATH" -b "$CONSOLE_PATH" $PARAMS --script "$EXPORT_SLICES"
}

export_cartridge() {
  echo "Exporting Cartridge"
  "$ASEPRITE_PATH" -b "$CARTRIDGE_PATH" $PARAMS --script "$EXPORT_SLICES"
}

export_directional_buttons() {
  echo "Exporting Directional Buttons"
      "$ASEPRITE_PATH" -b "$DIRECTIONAL_BUTTONS_PATH" $PARAMS --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_system_buttons() {
  echo "Exporting System Buttons"
      "$ASEPRITE_PATH" -b "$SYSTEM_BUTTONS_PATH" $PARAMS --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_controller() {
  echo "Exporting Controller"
      "$ASEPRITE_PATH" -b "$CONTROLLER_PATH" $PARAMS --script-param trim-cels="true" --script "$EXPORT_SLICES"
}

export_controller_diagrams() {
  echo "Exporting Controller Diagrams"
      "$ASEPRITE_PATH" -b "$CONTROLLER_DIAGRAMS_PATH" $PARAMS --script-param trim-cels="true" --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_indicators() {
  echo "Exporting Indicators"
      "$ASEPRITE_PATH" -b "$INDICATORS_PATH" $PARAMS --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_icons() {
  echo "Exporting Icons"
      "$ASEPRITE_PATH" -b "$ICONS_PATH" $PARAMS --script "$EXPORT_SLICES"
      "$ASEPRITE_PATH" -b "$ICONS_PATH" $PARAMS --script "$EXPORT_SHEET"
}

export_splash_screen() {
  echo "Exporting Logos"
      "$ASEPRITE_PATH" -b "$LOGOS_PATH" $PARAMS --script "$EXPORT_SLICES"
      "$ASEPRITE_PATH" -b "$LOGOS_PATH" $PARAMS --script "$EXPORT_SHEET"
}

export_logos() {
  echo "Exporting Splash Screen"
      "$ASEPRITE_PATH" -b "$SPLASH_PATH" $PARAMS --script-param trim="false" --script "$EXPORT_FOLDER_TAG_COMBINATIONS"
}

export_tv() {
  echo "Exporting TV"
      "$ASEPRITE_PATH" -b "$TV_PATH" $PARAMS --script "$EXPORT_TAGS"
}

while true; do
  display_menu
  read -p "Enter your choice [1-10]: " choice

  case $choice in
    1)
      export_face_buttons
      ;;
    2)
      export_directional_buttons
      ;;
    3)
      export_system_buttons
      ;;
    4)
      export_console
      export_cartridge
      ;;
    5)
      export_controller
      export_controller_diagrams
      ;;
    6)
      export_indicators
      ;;
    7)
      export_icons
      ;;
    8)
      export_splash_screen
      export_logos
      export_tv
      ;;
    9)
      echo "Exporting All"
      export_face_buttons
      export_directional_buttons
      export_system_buttons
      export_console
      export_cartridge
      export_controller
      export_controller_diagrams
      export_indicators
      export_icons
      export_splash_screen
      export_logos
      export_tv
      ;;
    10)
      echo "Exiting..."
      break
      ;;
    *)
      echo "Invalid option. Please try again."
      ;;
  esac

  echo ""
done