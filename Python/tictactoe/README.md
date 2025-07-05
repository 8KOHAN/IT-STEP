# Tic-Tac-Toe AI (Python)

A console-based **Tic-Tac-Toe** game where the player competes against an AI with adjustable difficulty: **easy**, **normal**, and **hard**. The game includes user-friendly prompts and randomized turn order.

---

## Features

- Classic 3×3 Tic-Tac-Toe board
- AI opponent with three difficulty levels:
  - **Easy**: random moves with minimal logic
  - **Normal**: prioritizes center and corners
  - **Hard**: uses basic minimax logic (win/block-win)
- Player chooses between `'X'` and `'O'`
- Detects win, draw, and invalid input
- Option to replay the game

---

## AI Logic Overview

### Easy Mode:
- Random moves, attempts to win if possible

### Normal Mode:
- Attempts to win
- Picks center if available
- Prefers corners over edges

### Hard Mode:
- Tries to win immediately
- Blocks opponent’s win
- Prioritizes center → corners → edges (mimics minimax pattern)
