package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public interface BinaryContourInterface {

    public interface Padded {
        boolean isCreatePaddedCopy();

        void setCoordinateAdjustment(int i, int i2);

        void setCreatePaddedCopy(boolean z);
    }

    List getContours();

    ConfigLength getMinContour(ConfigLength configLength);

    void loadContour(int i, DogArray dogArray);

    void setConnectRule(ConnectRule connectRule);

    void setMaxContour(ConfigLength configLength);

    void setMinContour(ConfigLength configLength);

    void setSaveInnerContour(boolean z);
}
