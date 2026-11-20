package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ContourTracerBase {
    protected GrayU8 binary;
    protected int dir;
    protected int indexBinary;
    protected int[] nextDirection;
    protected int[] offsetsBinary;
    protected final ConnectRule rule;
    protected final int ruleN;
    protected int x;
    protected int y;

    public ContourTracerBase(ConnectRule connectRule) {
        this.rule = connectRule;
        int i = 0;
        if (ConnectRule.EIGHT == connectRule) {
            this.nextDirection = new int[8];
            while (i < 8) {
                this.nextDirection[i] = (((i + 4) % 8) + 2) % 8;
                i++;
            }
            this.ruleN = 8;
        } else if (ConnectRule.FOUR == connectRule) {
            this.nextDirection = new int[4];
            while (i < 4) {
                this.nextDirection[i] = (((i + 2) % 4) + 1) % 4;
                i++;
            }
            this.ruleN = 4;
        } else {
            throw new IllegalArgumentException("Connectivity rule must be 4 or 8 not " + connectRule);
        }
        this.offsetsBinary = new int[this.ruleN];
    }

    public void setInputs(GrayU8 grayU8) {
        this.binary = grayU8;
        if (this.rule == ConnectRule.EIGHT) {
            setOffsets8(this.offsetsBinary, grayU8.stride);
        } else {
            setOffsets4(this.offsetsBinary, grayU8.stride);
        }
    }

    private void setOffsets8(int[] iArr, int i) {
        iArr[0] = 1;
        iArr[1] = i + 1;
        iArr[2] = i;
        iArr[3] = i - 1;
        iArr[4] = -1;
        iArr[5] = (-1) - i;
        iArr[6] = -i;
        iArr[7] = 1 - i;
    }

    private void setOffsets4(int[] iArr, int i) {
        iArr[0] = 1;
        iArr[1] = i;
        iArr[2] = -1;
        iArr[3] = -i;
    }
}
