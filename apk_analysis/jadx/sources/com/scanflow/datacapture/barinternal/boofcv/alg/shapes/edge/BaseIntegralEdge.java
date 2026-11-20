package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.ImageLineIntegral;
import com.scanflow.datacapture.barinternal.boofcv.core.image.FactoryGImageGray;
import com.scanflow.datacapture.barinternal.boofcv.core.image.GImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public abstract class BaseIntegralEdge {
    Class imageType;
    protected ImageLineIntegral integral = new ImageLineIntegral();
    protected GImageGray integralImage;

    public BaseIntegralEdge(Class cls) {
        this.imageType = cls;
        this.integralImage = FactoryGImageGray.create(cls);
    }

    public void setImage(ImageGray imageGray) {
        this.integralImage.wrap(imageGray);
        this.integral.setImage(this.integralImage);
    }
}
