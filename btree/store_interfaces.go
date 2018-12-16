package btree

func (id UUID) ToString() string{
	return string(id[:])
}
func ToUUID(id string) UUID{
	var bid = []byte(id)
	var nid UUID
	copy(nid[:], bid)
	return nid
}

// BtreeInterface defines publicly callable methods of Btree.
type BtreeInterface interface{
	Add(key interface{}, value interface{}) (bool, error)
}

// backend store persistence interfaces

type StoreInterface struct{
	StoreType uint
	StoreRepository StoreRepository
	NodeRepository NodeRepository
	VirtualIDRepository VirtualIDRepository
	RecyclerRepository RecyclerRepository
	TransactionRepository TransactionRepository
}

type StoreRepository interface{
	Get(name string) *Store
	Add(*Store) error
	Remove(name string) error
}

type NodeRepository interface{
	Get(nodeID UUID) (*Node, error)
	Add(*Node) error
	Update(*Node) error
	Remove(nodeID UUID) error
}

type VirtualIDRepository interface{
	Get(logicalID UUID) (*VirtualID, error)
	Add(*VirtualID) error
	Update(*VirtualID) error
	Remove(logicalID UUID) error
}

type RecyclerRepository interface{
	Get(batch int, objectType int) []*Recyclable
	Add(recyclables []*Recyclable) error
	Remove(items []*Recyclable) error
}

type TransactionRepository interface{
	Get(transactionID UUID) ([]*TransactionEntry, error)
	GetByStore(transactionID UUID, storeName string) ([]*TransactionEntry, error)
	Add([]*TransactionEntry) error
	//Update([]*TransactionEntry) error
	MarkDone([]*TransactionEntryKeys) error
}
