﻿using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	private int rows, columns;
	private int[,] board;
	
	private int currentPlayer; // 1 = BLUE, 2 = RED

	// Use this for initialization
	void Start () {
		Debug.Log ("Iniciar tablero");
		
		rows = 6;
		columns = 7;
		board = new int[rows, columns];
		
		Debug.Log ("[GAME] Comienza jugador Azul");
		currentPlayer = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addFicha(int col){
		for(int row = rows - 1; row >= 0; row--){		
			if (board[row, col] == 0){
				Debug.Log ("[GAME] Colocar ficha en posicion [" + row + ", " + col + "]");
				board[row, col] = currentPlayer;
				
				//placeChip(new Point(row,columnclicked))
				togglePlayer();
				//putChipReady();
				return;
			}
		}
		
		Debug.Log ("[GAME] Columna llena");
	}
	
	private void togglePlayer(){
		if (currentPlayer == 1) {
			currentPlayer = 2;
			Debug.Log ("[GAME] Turno jugador Rojo");
			return;
		}
		
		currentPlayer = 1;
		Debug.Log ("[GAME] Turno jugador Azul");
	}
	
	private bool fourInALine(int row, int col){
		if(verticalCheck(row, col)) return true;
		if(horizontalCheck(row, col)) return true;
		if(leftUpDiagonalCheck(row, col)) return true;
		if(rightUpDiagonalCheck(row, col)) return true;
		
		return false;
	}
	
	private bool verticalCheck(int row, int col){
		int player = board[row, col];
		
		// Verificar que la columna tenga al menos 4 fichas
		if (row >= rows - 3){
			return false;
		}
		
		// Verificar que las tres fichas de abajo sean del mismo color
		for (int i = row + 1; i <= row + 3; i++){
			if (board[i, col] != player){
				return false;
			}
		}
		
		Debug.Log ("4 en linea vertical");
		return true;
	}
	
	private bool horizontalCheck(int row, int col){
		int player = board[row, col], counter = 1;
		
		for(int i = col - 1; i >= 0; i--){
			if(board[row, i] != player){
				break;
			}
			counter++;
		}
		
		for(int j = col + 1; j < columns; j++) {
			if(board[row, j] != player){
				break;
			}
			counter++;
		}
		
		return (counter >= 4);
	}
	
	private bool leftUpDiagonalCheck(int row, int col){
		int player = board [row, col];
		int counter = 1;
		
		int r = row - 1;
		int c = col - 1;
		
		while (r >= 0 && c >= 0 && board[r, c] == player){
			counter++;
			r--;
			c--;
		}
		
		r = row + 1;
		c = col + 1;
		
		while (r < rows && c < columns && board[r, c] == player){            
			counter++;
			r++;
			c++;
		}
		
		return (counter >= 4);
	}
	
	private bool rightUpDiagonalCheck(int row, int col){
		int player = board [row, col];
		
		int r = row + 1;
		int c = col - 1;
		
		int counter = 1;
		
		while (r < rows && c >= 0 && board[r, c] == player){
			counter++;
			r++;
			c--;
		}
		
		r = row - 1;
		c = col + 1;
		
		while (r >= 0 && c < columns && board[r, c] == player){
			counter++;
			r--;
			c++;
		}
		
		return (counter >= 4);
	}
}