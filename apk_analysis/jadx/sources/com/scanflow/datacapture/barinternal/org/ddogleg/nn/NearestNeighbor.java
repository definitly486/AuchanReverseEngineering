package com.scanflow.datacapture.barinternal.org.ddogleg.nn;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public interface NearestNeighbor {

    public interface Search {
        void findNearest(Object obj, double d, int i, DogArray dogArray);
    }

    Search createSearch();

    void setPoints(List list, boolean z);
}
