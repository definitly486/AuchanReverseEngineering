package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur.BlurImageOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplThresholdImageOps_MT {
    public static GrayU8 threshold(final GrayF32 grayF32, final GrayU8 grayU8, final float f, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda16
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.m640$r8$lambda$XmA7l7CorlqxA7RWQ9jqyklDkU(grayF32, grayU8, f, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda17
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.m639$r8$lambda$VeSRL_t_6iPCjqcjgRJDbnwazQ(grayF32, grayU8, f, i);
            }
        });
        return grayU8;
    }

    /* JADX INFO: renamed from: $r8$lambda$XmA7l7CorlqxA7RWQ9jqyk-lDkU, reason: not valid java name */
    public static /* synthetic */ void m640$r8$lambda$XmA7l7CorlqxA7RWQ9jqyklDkU(GrayF32 grayF32, GrayU8 grayU8, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (i * grayU8.stride);
        int i4 = grayF32.width;
        while (i4 > 0) {
            int i5 = i3 + 1;
            int i6 = i2 + 1;
            grayU8.data[i3] = (byte) (grayF32.data[i2] <= f ? 1 : 0);
            i4--;
            i3 = i5;
            i2 = i6;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$VeSRL_t-_6iPCjqcjgRJDbnwazQ, reason: not valid java name */
    public static /* synthetic */ void m639$r8$lambda$VeSRL_t_6iPCjqcjgRJDbnwazQ(GrayF32 grayF32, GrayU8 grayU8, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (i * grayU8.stride);
        int i4 = grayF32.width;
        while (i4 > 0) {
            int i5 = i3 + 1;
            int i6 = i2 + 1;
            grayU8.data[i3] = (byte) (grayF32.data[i2] > f ? 1 : 0);
            i4--;
            i3 = i5;
            i2 = i6;
        }
    }

    public static GrayU8 threshold(final GrayF64 grayF64, final GrayU8 grayU8, final double d, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda8
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$vT__BKfe7J2iSp8PgJxmV4KXkRw(grayF64, grayU8, d, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda9
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$JS4RlNsMhWDUslc3cULM1kghGbE(grayF64, grayU8, d, i);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$vT__BKfe7J2iSp8PgJxmV4KXkRw(GrayF64 grayF64, GrayU8 grayU8, double d, int i) {
        int i2 = grayF64.startIndex + (grayF64.stride * i);
        int i3 = grayU8.startIndex + (i * grayU8.stride);
        int i4 = grayF64.width;
        while (i4 > 0) {
            int i5 = i3 + 1;
            int i6 = i2 + 1;
            grayU8.data[i3] = (byte) (grayF64.data[i2] <= d ? 1 : 0);
            i4--;
            i3 = i5;
            i2 = i6;
        }
    }

    public static /* synthetic */ void $r8$lambda$JS4RlNsMhWDUslc3cULM1kghGbE(GrayF64 grayF64, GrayU8 grayU8, double d, int i) {
        int i2 = grayF64.startIndex + (grayF64.stride * i);
        int i3 = grayU8.startIndex + (i * grayU8.stride);
        int i4 = grayF64.width;
        while (i4 > 0) {
            int i5 = i3 + 1;
            int i6 = i2 + 1;
            grayU8.data[i3] = (byte) (grayF64.data[i2] > d ? 1 : 0);
            i4--;
            i3 = i5;
            i2 = i6;
        }
    }

    public static GrayU8 threshold(final GrayU8 grayU8, final GrayU8 grayU9, final int i, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda14
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ImplThresholdImageOps_MT.$r8$lambda$rNjhXI97YM8inPDUeLc21wNc7io(grayU8, grayU9, i, i2);
                }
            });
            return grayU9;
        }
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda15
            @Override // java.util.function.IntConsumer
            public final void accept(int i2) {
                ImplThresholdImageOps_MT.$r8$lambda$kAbYuM5DPRdKdt1tDjvEbBlfKks(grayU8, grayU9, i, i2);
            }
        });
        return grayU9;
    }

    public static /* synthetic */ void $r8$lambda$rNjhXI97YM8inPDUeLc21wNc7io(GrayU8 grayU8, GrayU8 grayU9, int i, int i2) {
        int i3 = grayU8.startIndex + (grayU8.stride * i2);
        int i4 = grayU9.startIndex + (i2 * grayU9.stride);
        int i5 = grayU8.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU9.data[i4] = (byte) ((grayU8.data[i3] & UnsignedBytes.MAX_VALUE) <= i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static /* synthetic */ void $r8$lambda$kAbYuM5DPRdKdt1tDjvEbBlfKks(GrayU8 grayU8, GrayU8 grayU9, int i, int i2) {
        int i3 = grayU8.startIndex + (grayU8.stride * i2);
        int i4 = grayU9.startIndex + (i2 * grayU9.stride);
        int i5 = grayU8.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU9.data[i4] = (byte) ((grayU8.data[i3] & UnsignedBytes.MAX_VALUE) > i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static GrayU8 threshold(final GrayS16 grayS16, final GrayU8 grayU8, final int i, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayS16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda10
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ImplThresholdImageOps_MT.$r8$lambda$7VN2tCPrF829C1aTM9HufITA1j8(grayS16, grayU8, i, i2);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayS16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda11
            @Override // java.util.function.IntConsumer
            public final void accept(int i2) {
                ImplThresholdImageOps_MT.m641$r8$lambda$qkttMkZfpf0CBPxdqyi3ebXB78(grayS16, grayU8, i, i2);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$7VN2tCPrF829C1aTM9HufITA1j8(GrayS16 grayS16, GrayU8 grayU8, int i, int i2) {
        int i3 = grayS16.startIndex + (grayS16.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayS16.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayS16.data[i3] <= i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$qktt-MkZfpf0CBPxdqyi3ebXB78, reason: not valid java name */
    public static /* synthetic */ void m641$r8$lambda$qkttMkZfpf0CBPxdqyi3ebXB78(GrayS16 grayS16, GrayU8 grayU8, int i, int i2) {
        int i3 = grayS16.startIndex + (grayS16.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayS16.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayS16.data[i3] > i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static GrayU8 threshold(final GrayU16 grayU16, final GrayU8 grayU8, final int i, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda2
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ImplThresholdImageOps_MT.$r8$lambda$IgmUDAADl33PqJ_TGYvJajf9FWg(grayU16, grayU8, i, i2);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i2) {
                ImplThresholdImageOps_MT.$r8$lambda$iToHprxso2CkpMTjXEvR2njaVtI(grayU16, grayU8, i, i2);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$IgmUDAADl33PqJ_TGYvJajf9FWg(GrayU16 grayU16, GrayU8 grayU8, int i, int i2) {
        int i3 = grayU16.startIndex + (grayU16.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayU16.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) ((grayU16.data[i3] & 65535) <= i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static /* synthetic */ void $r8$lambda$iToHprxso2CkpMTjXEvR2njaVtI(GrayU16 grayU16, GrayU8 grayU8, int i, int i2) {
        int i3 = grayU16.startIndex + (grayU16.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayU16.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) ((grayU16.data[i3] & 65535) > i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static GrayU8 threshold(final GrayS32 grayS32, final GrayU8 grayU8, final int i, boolean z) {
        if (z) {
            ConcurrencyOps.loopFor(0, grayS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda12
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ImplThresholdImageOps_MT.$r8$lambda$2AdAP9D97eJraneJFObxflK4gls(grayS32, grayU8, i, i2);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda13
            @Override // java.util.function.IntConsumer
            public final void accept(int i2) {
                ImplThresholdImageOps_MT.$r8$lambda$ThjauhXqvNHeRgiY5helJMdD54M(grayS32, grayU8, i, i2);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$2AdAP9D97eJraneJFObxflK4gls(GrayS32 grayS32, GrayU8 grayU8, int i, int i2) {
        int i3 = grayS32.startIndex + (grayS32.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayS32.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayS32.data[i3] <= i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static /* synthetic */ void $r8$lambda$ThjauhXqvNHeRgiY5helJMdD54M(GrayS32 grayS32, GrayU8 grayU8, int i, int i2) {
        int i3 = grayS32.startIndex + (grayS32.stride * i2);
        int i4 = grayU8.startIndex + (i2 * grayU8.stride);
        int i5 = grayS32.width;
        while (i5 > 0) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayS32.data[i3] > i ? 1 : 0);
            i5--;
            i4 = i6;
            i3 = i7;
        }
    }

    public static GrayU8 localMean(final GrayU8 grayU8, final GrayU8 grayU9, ConfigLength configLength, final float f, boolean z, final GrayU8 grayU10, GrayU8 grayU11, GrowArray growArray) {
        BlurImageOps.mean(grayU8, grayU10, configLength.computeI(Math.min(grayU8.width, grayU8.height)) / 2, grayU11, growArray);
        if (z) {
            ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$jvtMmmvPL6OgZTX8Y0EsG5qKAds(grayU8, grayU9, grayU10, f, i);
                }
            });
            return grayU9;
        }
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.m642$r8$lambda$vBDzEjo1Dh5BVnBBxHjrMd4H8(grayU8, grayU9, grayU10, f, i);
            }
        });
        return grayU9;
    }

    public static /* synthetic */ void $r8$lambda$jvtMmmvPL6OgZTX8Y0EsG5qKAds(GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10, float f, int i) {
        int i2 = grayU8.startIndex + (grayU8.stride * i);
        int i3 = grayU9.startIndex + (grayU9.stride * i);
        int i4 = grayU10.startIndex + (i * grayU10.stride);
        int i5 = grayU8.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU9.data[i3] = ((float) (grayU8.data[i2] & UnsignedBytes.MAX_VALUE)) <= ((float) (grayU10.data[i4] & UnsignedBytes.MAX_VALUE)) * f ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$vBDzEjo-1Dh5BVn-BBxHjrMd4H8, reason: not valid java name */
    public static /* synthetic */ void m642$r8$lambda$vBDzEjo1Dh5BVnBBxHjrMd4H8(GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10, float f, int i) {
        int i2 = grayU8.startIndex + (grayU8.stride * i);
        int i3 = grayU9.startIndex + (grayU9.stride * i);
        int i4 = grayU10.startIndex + (i * grayU10.stride);
        int i5 = grayU8.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU9.data[i3] = ((float) (grayU8.data[i2] & UnsignedBytes.MAX_VALUE)) * f > ((float) (grayU10.data[i4] & UnsignedBytes.MAX_VALUE)) ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    public static GrayU8 localGaussian(final GrayU8 grayU8, final GrayU8 grayU9, ConfigLength configLength, final float f, boolean z, final GrayU8 grayU10, GrayU8 grayU11) {
        BlurImageOps.gaussian(grayU8, grayU10, -1.0d, configLength.computeI(Math.min(grayU8.width, grayU8.height)) / 2, grayU11);
        if (z) {
            ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda4
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$WXnanuaN5c6c5kVRm6a8XXyn_JM(grayU8, grayU9, grayU10, f, i);
                }
            });
            return grayU9;
        }
        ConcurrencyOps.loopFor(0, grayU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$rYU_rHN7HSEzWQB34Je1JF4v47w(grayU8, grayU9, grayU10, f, i);
            }
        });
        return grayU9;
    }

    public static /* synthetic */ void $r8$lambda$WXnanuaN5c6c5kVRm6a8XXyn_JM(GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10, float f, int i) {
        int i2 = grayU8.startIndex + (grayU8.stride * i);
        int i3 = grayU9.startIndex + (grayU9.stride * i);
        int i4 = grayU10.startIndex + (i * grayU10.stride);
        int i5 = grayU8.width + i2;
        while (i2 < i5) {
            if ((grayU8.data[i2] & UnsignedBytes.MAX_VALUE) <= (grayU10.data[i4] & UnsignedBytes.MAX_VALUE) * f) {
                grayU9.data[i3] = 1;
            } else {
                grayU9.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }

    public static /* synthetic */ void $r8$lambda$rYU_rHN7HSEzWQB34Je1JF4v47w(GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10, float f, int i) {
        int i2 = grayU8.startIndex + (grayU8.stride * i);
        int i3 = grayU9.startIndex + (grayU9.stride * i);
        int i4 = grayU10.startIndex + (i * grayU10.stride);
        int i5 = grayU8.width + i2;
        while (i2 < i5) {
            if ((grayU8.data[i2] & UnsignedBytes.MAX_VALUE) * f > (grayU10.data[i4] & UnsignedBytes.MAX_VALUE)) {
                grayU9.data[i3] = 1;
            } else {
                grayU9.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }

    public static GrayU8 localMean(final GrayU16 grayU16, final GrayU8 grayU8, ConfigLength configLength, final float f, boolean z, final GrayU16 grayU17, GrayU16 grayU18, GrowArray growArray) {
        BlurImageOps.mean(grayU16, grayU17, configLength.computeI(Math.min(grayU16.width, grayU16.height)) / 2, grayU18, growArray);
        if (z) {
            ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda20
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.m638$r8$lambda$GnfCAblNXgod9vqOH6wofi8NTU(grayU16, grayU8, grayU17, f, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda21
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$RFa7C3tCC2T_vLJJnHufDnWjhPk(grayU16, grayU8, grayU17, f, i);
            }
        });
        return grayU8;
    }

    /* JADX INFO: renamed from: $r8$lambda$Gn-fCAblNXgod9vqOH6wofi8NTU, reason: not valid java name */
    public static /* synthetic */ void m638$r8$lambda$GnfCAblNXgod9vqOH6wofi8NTU(GrayU16 grayU16, GrayU8 grayU8, GrayU16 grayU17, float f, int i) {
        int i2 = grayU16.startIndex + (grayU16.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayU17.startIndex + (i * grayU17.stride);
        int i5 = grayU16.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU8.data[i3] = ((float) (grayU16.data[i2] & 65535)) <= ((float) (grayU17.data[i4] & 65535)) * f ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    public static /* synthetic */ void $r8$lambda$RFa7C3tCC2T_vLJJnHufDnWjhPk(GrayU16 grayU16, GrayU8 grayU8, GrayU16 grayU17, float f, int i) {
        int i2 = grayU16.startIndex + (grayU16.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayU17.startIndex + (i * grayU17.stride);
        int i5 = grayU16.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU8.data[i3] = ((float) (grayU16.data[i2] & 65535)) * f > ((float) (grayU17.data[i4] & 65535)) ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    public static GrayU8 localGaussian(final GrayU16 grayU16, final GrayU8 grayU8, ConfigLength configLength, final float f, boolean z, final GrayU16 grayU17, GrayU16 grayU18) {
        BlurImageOps.gaussian(grayU16, grayU17, -1.0d, configLength.computeI(Math.min(grayU16.width, grayU16.height)) / 2, grayU18);
        if (z) {
            ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda6
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$IpMu9dH1wX7xgi7lrYgNg_cWagk(grayU16, grayU8, grayU17, f, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda7
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$kIV4vatD8hOBs7TrAJimP2lCei8(grayU16, grayU8, grayU17, f, i);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$IpMu9dH1wX7xgi7lrYgNg_cWagk(GrayU16 grayU16, GrayU8 grayU8, GrayU16 grayU17, float f, int i) {
        int i2 = grayU16.startIndex + (grayU16.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayU17.startIndex + (i * grayU17.stride);
        int i5 = grayU16.width + i2;
        while (i2 < i5) {
            if ((65535 & grayU16.data[i2]) <= (grayU17.data[i4] & 65535) * f) {
                grayU8.data[i3] = 1;
            } else {
                grayU8.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }

    public static /* synthetic */ void $r8$lambda$kIV4vatD8hOBs7TrAJimP2lCei8(GrayU16 grayU16, GrayU8 grayU8, GrayU16 grayU17, float f, int i) {
        int i2 = grayU16.startIndex + (grayU16.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayU17.startIndex + (i * grayU17.stride);
        int i5 = grayU16.width + i2;
        while (i2 < i5) {
            if ((65535 & grayU16.data[i2]) * f > (grayU17.data[i4] & 65535)) {
                grayU8.data[i3] = 1;
            } else {
                grayU8.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }

    public static GrayU8 localMean(final GrayF32 grayF32, final GrayU8 grayU8, ConfigLength configLength, final float f, boolean z, final GrayF32 grayF33, GrayF32 grayF34, GrowArray growArray) {
        BlurImageOps.mean(grayF32, grayF33, configLength.computeI(Math.min(grayF32.width, grayF32.height)) / 2, grayF34, growArray);
        if (z) {
            ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda22
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$9J6lngSn9VicLtsGyFWgCYdRGv4(grayF32, grayU8, grayF33, f, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda23
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$2tK6urmRJ2cCEgmU9GrD8QkITWE(grayF32, grayU8, grayF33, f, i);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$9J6lngSn9VicLtsGyFWgCYdRGv4(GrayF32 grayF32, GrayU8 grayU8, GrayF32 grayF33, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayF33.startIndex + (i * grayF33.stride);
        int i5 = grayF32.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU8.data[i3] = grayF32.data[i2] <= grayF33.data[i4] * f ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    public static /* synthetic */ void $r8$lambda$2tK6urmRJ2cCEgmU9GrD8QkITWE(GrayF32 grayF32, GrayU8 grayU8, GrayF32 grayF33, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayF33.startIndex + (i * grayF33.stride);
        int i5 = grayF32.width + i2;
        while (i2 < i5) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            int i8 = i2 + 1;
            grayU8.data[i3] = grayF32.data[i2] * f > grayF33.data[i4] ? (byte) 1 : (byte) 0;
            i4 = i6;
            i3 = i7;
            i2 = i8;
        }
    }

    public static GrayU8 localGaussian(final GrayF32 grayF32, final GrayU8 grayU8, ConfigLength configLength, final float f, boolean z, final GrayF32 grayF33, GrayF32 grayF34) {
        BlurImageOps.gaussian(grayF32, grayF33, -1.0d, configLength.computeI(Math.min(grayF32.width, grayF32.height)) / 2, grayF34);
        if (z) {
            ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda18
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplThresholdImageOps_MT.$r8$lambda$I0rf3cAavYtIx0UI233tyU0LRmU(grayF32, grayU8, grayF33, f, i);
                }
            });
            return grayU8;
        }
        ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT$$ExternalSyntheticLambda19
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplThresholdImageOps_MT.$r8$lambda$46qDHGtpefM5Oy9Tfm7il7cdoZw(grayF32, grayU8, grayF33, f, i);
            }
        });
        return grayU8;
    }

    public static /* synthetic */ void $r8$lambda$I0rf3cAavYtIx0UI233tyU0LRmU(GrayF32 grayF32, GrayU8 grayU8, GrayF32 grayF33, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayF33.startIndex + (i * grayF33.stride);
        int i5 = grayF32.width + i2;
        while (i2 < i5) {
            if (grayF32.data[i2] <= grayF33.data[i4] * f) {
                grayU8.data[i3] = 1;
            } else {
                grayU8.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }

    public static /* synthetic */ void $r8$lambda$46qDHGtpefM5Oy9Tfm7il7cdoZw(GrayF32 grayF32, GrayU8 grayU8, GrayF32 grayF33, float f, int i) {
        int i2 = grayF32.startIndex + (grayF32.stride * i);
        int i3 = grayU8.startIndex + (grayU8.stride * i);
        int i4 = grayF33.startIndex + (i * grayF33.stride);
        int i5 = grayF32.width + i2;
        while (i2 < i5) {
            if (grayF32.data[i2] * f > grayF33.data[i4]) {
                grayU8.data[i3] = 1;
            } else {
                grayU8.data[i3] = 0;
            }
            i2++;
            i3++;
            i4++;
        }
    }
}
