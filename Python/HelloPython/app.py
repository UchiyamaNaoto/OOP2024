from dataclasses import dataclass

@dataclass #クラスの定義
class Item:
    kind: str
    price : int

def tax_included_price(item):
    if item.kind == "food":
        return round(item.price * 1.08)
    else:
        return round(item.price * 1.1)

def total_amount(items):
    amounts = [tax_included_price(item) for item in items] #内包表記
    return sum(amounts)

items = [Item("food",200),
         Item("book",1000),
         Item("food",100),]
print(total_amount(items))



