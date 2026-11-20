package com.scanflow.datacapture.barinternal.kotlin.sequences;

import com.scanflow.datacapture.barinternal.kotlin.collections.EmptyIterator;
import java.util.Iterator;

/* JADX INFO: compiled from: Sequences.kt */
/* JADX INFO: loaded from: classes3.dex */
final class EmptySequence implements Sequence, DropTakeSequence {
    public static final EmptySequence INSTANCE = new EmptySequence();

    private EmptySequence() {
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.sequences.Sequence
    public Iterator iterator() {
        return EmptyIterator.INSTANCE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.sequences.DropTakeSequence
    public EmptySequence drop(int i) {
        return INSTANCE;
    }
}
