# No More Falling Fuel

A [Vintage Story](https://vintagestory.at/) mod that prevents fuel piles (charcoal, coal, and coke) from collapsing or falling. After installing this mod, fuel piles behave like peat and firewood stacks — they stay where you put them.

## Features

- Prevents coal piles from collapsing sideways when you add or remove items
- Prevents charcoal piles from falling when blocks beneath them are removed
- Covers all fuel types: charcoal, anthracite, bituminous coal, lignite, brown coal, and coke
- Configurable per-item-type — choose exactly which fuels are protected
- Does not affect burning, coke conversion, or any other fuel mechanics

## Installation

1. Download the latest release zip
2. Place it in your `Mods` folder (do not extract)
3. Start the game — a default config file will be created on first load

## Configuration

A config file `nomorefallingfuel.json` is created in your Vintage Story mod config directory on first run.

```json
{
  "ProtectedItems": [
    "charcoal",
    "coal-anthracite",
    "coal-bituminous",
    "coal-lignite",
    "coal-brown",
    "coke"
  ],
  "PreventCharcoalPileFalling": true
}
```

- **ProtectedItems** — Item codes for fuels whose coal piles should not collapse sideways. Add or remove entries to customize.
- **PreventCharcoalPileFalling** — Set to `false` to restore vanilla charcoal pile falling behavior.

Changes require a game restart.

## Compatibility

- Vintage Story 1.21.6+
- Works on both singleplayer and multiplayer (Universal mod)

## Building from Source

Requires the `VINTAGE_STORY` environment variable pointing to your Vintage Story installation:

```bash
export VINTAGE_STORY=~/.local/share/vintagestory
dotnet build -c Release
# Or to create a release zip:
bash build.sh
```
