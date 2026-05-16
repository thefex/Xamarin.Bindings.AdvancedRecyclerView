#!/usr/bin/env bash
# Builds the Android AAR from the android-advancedrecyclerview submodule
# and copies it to the .NET binding project's Jars directory.
#
# Usage: ./build-aar.sh [release|debug]
#
# Prerequisites:
#   - Android SDK installed with ANDROID_HOME set
#   - Java 17+ available on PATH

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SUBMODULE_DIR="$SCRIPT_DIR/android-advancedrecyclerview"
JARS_DIR="$SCRIPT_DIR/AdvancedRecyclerView/Bindings/Jars"
BUILD_TYPE="${1:-release}"

echo "==> Initialising submodule..."
git -C "$SCRIPT_DIR" submodule update --init --recursive

echo "==> Building AAR (${BUILD_TYPE})..."
cd "$SUBMODULE_DIR"

if [ "$BUILD_TYPE" = "release" ]; then
    ./gradlew :library:assembleRelease
    AAR_SRC="$SUBMODULE_DIR/library/build/outputs/aar/library-release.aar"
else
    ./gradlew :library:assembleDebug
    AAR_SRC="$SUBMODULE_DIR/library/build/outputs/aar/library-debug.aar"
fi

echo "==> Copying AAR to Jars directory..."
mkdir -p "$JARS_DIR"
cp "$AAR_SRC" "$JARS_DIR/advrecyclerview.aar"

echo "==> Done. AAR written to: $JARS_DIR/advrecyclerview.aar"
