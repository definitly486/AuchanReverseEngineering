package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.misc.ImageMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import com.scanflow.datacapture.barinternal.boofcv.struct.PackedSetsPoint2D_I32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public class LinearExternalContours {
    private int adjustX;
    private int adjustY;
    private int maxContourLengthPixels;
    private int minContourLengthPixels;
    private Tracer tracer;
    private ConfigLength maxContourLength = ConfigLength.fixed(-1.0d);
    private ConfigLength minContourLength = ConfigLength.fixed(0.0d);
    private final PackedSetsPoint2D_I32 storagePoints = new PackedSetsPoint2D_I32();

    public void setMaxContourLength(ConfigLength configLength) {
        this.maxContourLength = configLength;
    }

    public ConfigLength getMinContourLength() {
        return this.minContourLength;
    }

    public void setMinContourLength(ConfigLength configLength) {
        this.minContourLength = configLength;
    }

    public LinearExternalContours(ConnectRule connectRule) {
        this.tracer = new Tracer(connectRule);
    }

    public void process(GrayU8 grayU8, int i, int i2) {
        int iSizeOfTail;
        this.minContourLengthPixels = this.minContourLength.computeNegMaxI(Math.sqrt(grayU8.width * grayU8.height));
        this.maxContourLengthPixels = this.maxContourLength.computeNegMaxI(Math.sqrt(grayU8.width * grayU8.height));
        this.adjustX = i;
        this.adjustY = i2;
        this.storagePoints.reset();
        ImageMiscOps.fillBorder(grayU8, 0, 1);
        this.tracer.setInputs(grayU8);
        byte[] bArr = grayU8.data;
        for (int i3 = 1; i3 < grayU8.height - 1; i3++) {
            int i4 = grayU8.startIndex + (grayU8.stride * i3) + 1;
            int i5 = (grayU8.width + i4) - 2;
            int i6 = 1;
            while (true) {
                int iFindNotZero = findNotZero(bArr, i4, i5) - i4;
                int i7 = i4 + iFindNotZero;
                if (i7 == i5) {
                    break;
                }
                int i8 = i6 + iFindNotZero;
                if (bArr[i7] == 1 && (!this.tracer.trace(i8, i3, true) || (iSizeOfTail = this.storagePoints.sizeOfTail()) < this.minContourLengthPixels || iSizeOfTail >= this.maxContourLengthPixels)) {
                    this.storagePoints.removeTail();
                }
                int iFindZero = findZero(bArr, i7, i5) - i7;
                i4 = i7 + iFindZero;
                if (i4 == i5) {
                    break;
                }
                i6 = i8 + iFindZero;
                int i9 = i4 - 1;
                if (bArr[i9] == 1) {
                    this.tracer.trace(i6 - 1, i3, false);
                    this.storagePoints.removeTail();
                } else {
                    bArr[i9] = -2;
                }
            }
        }
    }

    static int findNotZero(byte[] bArr, int i, int i2) {
        while (i < i2 && bArr[i] == 0) {
            i++;
        }
        return i;
    }

    static int findZero(byte[] bArr, int i, int i2) {
        while (i < i2 && bArr[i] != 0) {
            i++;
        }
        return i;
    }

    class Tracer extends ContourTracerBase {
        public int maxContourLengthPixels;

        public Tracer(ConnectRule connectRule) {
            super(connectRule);
            this.maxContourLengthPixels = Integer.MAX_VALUE;
        }

        /* JADX WARN: Code duplicated, block: B:12:0x0030  */
        public boolean trace(int i, int i2, boolean z) {
            if (z) {
                int index = this.binary.getIndex(i, i2);
                this.indexBinary = index;
                if (this.rule == ConnectRule.EIGHT) {
                    byte[] bArr = this.binary.data;
                    int[] iArr = this.offsetsBinary;
                    if (bArr[iArr[5] + index] != 0 || bArr[iArr[6] + index] != 0 || bArr[index + iArr[7]] != 0) {
                        z = false;
                    }
                } else if (this.binary.data[index + this.offsetsBinary[3]] != 0) {
                    z = false;
                }
            }
            if (z) {
                this.maxContourLengthPixels = LinearExternalContours.this.maxContourLengthPixels;
            } else {
                this.maxContourLengthPixels = -1;
            }
            LinearExternalContours.this.storagePoints.grow();
            if (this.rule == ConnectRule.EIGHT) {
                this.dir = z ? 7 : 6;
            } else {
                this.dir = z ? 0 : 3;
            }
            this.x = i;
            this.y = i2;
            this.indexBinary = this.binary.getIndex(i, i2);
            LinearExternalContours.this.storagePoints.addPointToTail(this.x - LinearExternalContours.this.adjustX, this.y - LinearExternalContours.this.adjustY);
            this.binary.data[this.indexBinary] = -2;
            if (!searchNotZero()) {
                return true;
            }
            int i3 = this.dir;
            moveToNext();
            this.dir = this.nextDirection[this.dir];
            while (true) {
                searchNotZero();
                byte[] bArr2 = this.binary.data;
                int i4 = this.indexBinary;
                if (bArr2[i4] != -2) {
                    bArr2[i4] = -1;
                } else {
                    if (this.x != i || this.y != i2) {
                        break;
                    }
                    if (this.dir == i3) {
                        return z;
                    }
                }
                if (LinearExternalContours.this.storagePoints.sizeOfTail() <= this.maxContourLengthPixels) {
                    LinearExternalContours.this.storagePoints.addPointToTail(this.x - LinearExternalContours.this.adjustX, this.y - LinearExternalContours.this.adjustY);
                }
                moveToNext();
                this.dir = this.nextDirection[this.dir];
            }
            return false;
        }

        private boolean searchNotZero() {
            if (this.ruleN == 4) {
                return searchNotOne4();
            }
            return searchNotOne8();
        }

        private boolean searchNotOne4() {
            byte[] bArr = this.binary.data;
            int i = this.indexBinary;
            int[] iArr = this.offsetsBinary;
            int i2 = this.dir;
            if (bArr[iArr[i2] + i] != 0) {
                return true;
            }
            int i3 = (i2 + 1) % 4;
            this.dir = i3;
            if (bArr[iArr[i3] + i] != 0) {
                return true;
            }
            int i4 = (i3 + 1) % 4;
            this.dir = i4;
            if (bArr[iArr[i4] + i] != 0) {
                return true;
            }
            int i5 = (i4 + 1) % 4;
            this.dir = i5;
            if (bArr[i + iArr[i5]] != 0) {
                return true;
            }
            this.dir = (i5 + 1) % 4;
            return false;
        }

        private boolean searchNotOne8() {
            byte[] bArr = this.binary.data;
            int i = this.indexBinary;
            int[] iArr = this.offsetsBinary;
            int i2 = this.dir;
            if (bArr[iArr[i2] + i] != 0) {
                return true;
            }
            int i3 = (i2 + 1) % 8;
            this.dir = i3;
            if (bArr[iArr[i3] + i] != 0) {
                return true;
            }
            int i4 = (i3 + 1) % 8;
            this.dir = i4;
            if (bArr[iArr[i4] + i] != 0) {
                return true;
            }
            int i5 = (i4 + 1) % 8;
            this.dir = i5;
            if (bArr[iArr[i5] + i] != 0) {
                return true;
            }
            int i6 = (i5 + 1) % 8;
            this.dir = i6;
            if (bArr[iArr[i6] + i] != 0) {
                return true;
            }
            int i7 = (i6 + 1) % 8;
            this.dir = i7;
            if (bArr[iArr[i7] + i] != 0) {
                return true;
            }
            int i8 = (i7 + 1) % 8;
            this.dir = i8;
            if (bArr[iArr[i8] + i] != 0) {
                return true;
            }
            int i9 = (i8 + 1) % 8;
            this.dir = i9;
            if (bArr[i + iArr[i9]] != 0) {
                return true;
            }
            this.dir = (i9 + 1) % 8;
            return false;
        }

        private void moveToNext() {
            int i = this.indexBinary + this.offsetsBinary[this.dir];
            this.indexBinary = i;
            GrayU8 grayU8 = this.binary;
            int i2 = i - grayU8.startIndex;
            int i3 = grayU8.stride;
            this.x = i2 % i3;
            this.y = i2 / i3;
        }
    }

    public void setConnectRule(ConnectRule connectRule) {
        this.tracer = new Tracer(connectRule);
    }

    public PackedSetsPoint2D_I32 getExternalContours() {
        return this.storagePoints;
    }
}
