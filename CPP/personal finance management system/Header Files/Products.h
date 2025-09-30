#pragma once
struct AmountProducts
{
	int ps5       = 0;
	int kettle    = 0;
	int battery   = 0;
	int cigarette = 0;
	int snickers  = 0;
	int propolis  = 0;
	int house     = 0;
	int keyboard  = 0;
	int flower    = 0;
};

struct InStockProducts 
{
	int ps5       = rand() % 3;
	int kettle    = rand() % 15;
	int battery   = rand() % 300;
	int cigarette = 1;
	int snickers  = rand() % 30;
	int propolis  = rand() % 10;
	int house     = 1;
	int keyboard  = rand() % 5;
	int flower    = rand() % 25;
};
