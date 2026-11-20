namespace DryIoc.ImTools;

public delegate V Update<V>(V oldValue, V newValue);
public delegate V Update<K, V>(K key, V oldValue, V newValue);
