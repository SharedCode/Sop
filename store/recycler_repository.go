package store;

import "../btree"

type Recyclable struct{
	Year int
	Month int
	Day int
	Hour int
	btree.Recyclable
}

func NewRecycler() btree.Recycler{
	return Recyclable{};
}

func (Recyclable) Get(batch int, objectType int) []*btree.Recyclable{
	return nil;
}
func (Recyclable) Add(recyclable []*btree.Recyclable) error{
	//var iface interface{} = recyclable
	//item := iface.(Recyclable)
	return nil;
}
// func (Recyclable) Update(*btree.Recyclable) error{
// 	return nil;
// }
func (Recyclable) Remove(items []*btree.Recyclable) error{
	return nil;
}
