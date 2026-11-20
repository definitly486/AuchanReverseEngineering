package com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.core.image.GConvertImage;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;

/* JADX INFO: loaded from: classes.dex */
public class InputToBinarySwitch implements InputToBinary {
    InputToBinary alg;
    ImageType inputType;
    ImageGray work;

    public InputToBinarySwitch(InputToBinary inputToBinary, Class cls) {
        this.alg = inputToBinary;
        this.inputType = ImageType.single(cls);
        if (inputToBinary.getInputType().isSameType(this.inputType)) {
            return;
        }
        this.work = (ImageGray) inputToBinary.getInputType().createImage(1, 1);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(ImageGray imageGray, GrayU8 grayU8) {
        grayU8.reshape(imageGray);
        ImageGray imageGray2 = this.work;
        if (imageGray2 == null) {
            this.alg.process(imageGray, grayU8);
            return;
        }
        imageGray2.reshape(imageGray);
        GConvertImage.convert(imageGray, this.work);
        this.alg.process(this.work, grayU8);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.inputType;
    }
}
