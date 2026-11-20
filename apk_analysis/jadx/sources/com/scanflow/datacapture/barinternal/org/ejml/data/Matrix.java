package com.scanflow.datacapture.barinternal.org.ejml.data;

import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public interface Matrix extends Serializable {
    Matrix copy();

    Matrix create(int i, int i2);

    int getNumCols();

    int getNumRows();

    MatrixType getType();
}
