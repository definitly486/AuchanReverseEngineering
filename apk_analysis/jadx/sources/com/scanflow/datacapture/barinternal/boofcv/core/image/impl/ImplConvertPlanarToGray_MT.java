package com.scanflow.datacapture.barinternal.boofcv.core.image.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.Planar;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplConvertPlanarToGray_MT {
    public static void average(final Planar planar, final GrayU8 grayU8) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayU8.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayU8 grayU9 = (GrayU8) planar.getBand(0);
            final GrayU8 grayU10 = (GrayU8) planar.getBand(1);
            final GrayU8 grayU11 = (GrayU8) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda8
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.$r8$lambda$8EePyDZrRb5RaaoCORqC5zbMo_U(planar, grayU8, grayU9, grayU10, grayU11, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda9
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.m676$r8$lambda$_ANHPtnU98VSVtPPVfcAaCFA(planar, grayU8, numBands, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$8EePyDZrRb5RaaoCORqC5zbMo_U(Planar planar, GrayU8 grayU8, GrayU8 grayU9, GrayU8 grayU10, GrayU8 grayU11, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayU8.getIndex(0, i);
        while (i2 < planar.width) {
            grayU8.data[index2] = (byte) ((((grayU9.data[index] & UnsignedBytes.MAX_VALUE) + (grayU10.data[index] & UnsignedBytes.MAX_VALUE)) + (grayU11.data[index] & UnsignedBytes.MAX_VALUE)) / 3);
            i2++;
            index++;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$_ANHPtn-U9-8-VSVtPPVfcAaCFA, reason: not valid java name */
    public static /* synthetic */ void m676$r8$lambda$_ANHPtnU98VSVtPPVfcAaCFA(Planar planar, GrayU8 grayU8, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayU8.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                i4 += ((GrayU8[]) planar.bands)[i5].data[index] & UnsignedBytes.MAX_VALUE;
            }
            grayU8.data[index2] = (byte) (i4 / i);
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayS8 grayS8) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS8.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayS8 grayS9 = (GrayS8) planar.getBand(0);
            final GrayS8 grayS10 = (GrayS8) planar.getBand(1);
            final GrayS8 grayS11 = (GrayS8) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda2
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.$r8$lambda$lN3R2hYQYCMVibOhGHaFilMjqx8(planar, grayS8, grayS9, grayS10, grayS11, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda3
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.m672$r8$lambda$CkqFFBMQnpUL_qu3fIKS_rzbAk(planar, grayS8, numBands, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$lN3R2hYQYCMVibOhGHaFilMjqx8(Planar planar, GrayS8 grayS8, GrayS8 grayS9, GrayS8 grayS10, GrayS8 grayS11, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayS8.getIndex(0, i);
        while (i2 < planar.width) {
            grayS8.data[index2] = (byte) (((grayS9.data[index] + grayS10.data[index]) + grayS11.data[index]) / 3);
            i2++;
            index++;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$CkqFFBMQnpUL_qu3fIK-S_rzbAk, reason: not valid java name */
    public static /* synthetic */ void m672$r8$lambda$CkqFFBMQnpUL_qu3fIKS_rzbAk(Planar planar, GrayS8 grayS8, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayS8.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                i4 += ((GrayS8[]) planar.bands)[i5].data[index];
            }
            grayS8.data[index2] = (byte) (i4 / i);
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayU16 grayU16) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayU16.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayU16 grayU17 = (GrayU16) planar.getBand(0);
            final GrayU16 grayU18 = (GrayU16) planar.getBand(1);
            final GrayU16 grayU19 = (GrayU16) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda12
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.$r8$lambda$6yXkaxKSKbRdBPsdYnbhV_wT7PM(planar, grayU16, grayU17, grayU18, grayU19, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda13
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.m673$r8$lambda$EPsbTrbjZT6Zss6cSVk_0SN_G4(planar, grayU16, numBands, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$6yXkaxKSKbRdBPsdYnbhV_wT7PM(Planar planar, GrayU16 grayU16, GrayU16 grayU17, GrayU16 grayU18, GrayU16 grayU19, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayU16.getIndex(0, i);
        while (i2 < planar.width) {
            grayU16.data[index2] = (short) ((((grayU17.data[index] & 65535) + (grayU18.data[index] & 65535)) + (65535 & grayU19.data[index])) / 3);
            i2++;
            index++;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$EPsbTrbjZT6Z-ss6cSVk_0SN_G4, reason: not valid java name */
    public static /* synthetic */ void m673$r8$lambda$EPsbTrbjZT6Zss6cSVk_0SN_G4(Planar planar, GrayU16 grayU16, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayU16.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                i4 += ((GrayU16[]) planar.bands)[i5].data[index] & 65535;
            }
            grayU16.data[index2] = (short) (i4 / i);
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayS16 grayS16) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS16.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayS16 grayS17 = (GrayS16) planar.getBand(0);
            final GrayS16 grayS18 = (GrayS16) planar.getBand(1);
            final GrayS16 grayS19 = (GrayS16) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda6
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.m678$r8$lambda$tb4hQSOdMkaxqRfMGeYnZnTAPg(planar, grayS16, grayS17, grayS18, grayS19, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda7
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.$r8$lambda$sG6sABLv7fUAxFH2BFt05jSA01k(planar, grayS16, numBands, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$tb4hQSOdMkaxqRfM-GeYnZnTAPg, reason: not valid java name */
    public static /* synthetic */ void m678$r8$lambda$tb4hQSOdMkaxqRfMGeYnZnTAPg(Planar planar, GrayS16 grayS16, GrayS16 grayS17, GrayS16 grayS18, GrayS16 grayS19, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayS16.getIndex(0, i);
        while (i2 < planar.width) {
            grayS16.data[index2] = (short) (((grayS17.data[index] + grayS18.data[index]) + grayS19.data[index]) / 3);
            i2++;
            index++;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$sG6sABLv7fUAxFH2BFt05jSA01k(Planar planar, GrayS16 grayS16, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayS16.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                i4 += ((GrayS16[]) planar.bands)[i5].data[index];
            }
            grayS16.data[index2] = (short) (i4 / i);
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayS32 grayS32) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS32.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayS32 grayS33 = (GrayS32) planar.getBand(0);
            final GrayS32 grayS34 = (GrayS32) planar.getBand(1);
            final GrayS32 grayS35 = (GrayS32) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda10
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.$r8$lambda$cLostc2k0_cZ3k3VNlRsPA01Zoo(planar, grayS32, grayS33, grayS34, grayS35, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda11
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.$r8$lambda$DNGKJhP51LGsE8kCGUrfQ0goswc(planar, grayS32, numBands, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$cLostc2k0_cZ3k3VNlRsPA01Zoo(Planar planar, GrayS32 grayS32, GrayS32 grayS33, GrayS32 grayS34, GrayS32 grayS35, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayS32.getIndex(0, i);
        while (i2 < planar.width) {
            grayS32.data[index2] = ((grayS33.data[index] + grayS34.data[index]) + grayS35.data[index]) / 3;
            i2++;
            index++;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$DNGKJhP51LGsE8kCGUrfQ0goswc(Planar planar, GrayS32 grayS32, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayS32.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            int i4 = 0;
            for (int i5 = 0; i5 < i; i5++) {
                i4 += ((GrayS32[]) planar.bands)[i5].data[index];
            }
            grayS32.data[index2] = i4 / i;
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayS64 grayS64) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayS64.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayS64 grayS65 = (GrayS64) planar.getBand(0);
            final GrayS64 grayS66 = (GrayS64) planar.getBand(1);
            final GrayS64 grayS67 = (GrayS64) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda14
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.m677$r8$lambda$iTbMCq5AiGraicD5ZVMw52XWZM(planar, grayS64, grayS65, grayS66, grayS67, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda15
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.$r8$lambda$yf8qdaHiVZb2SdvrxPrFPpwWF2s(planar, grayS64, numBands, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$iTbMCq5AiGra-icD5ZVMw52XWZM, reason: not valid java name */
    public static /* synthetic */ void m677$r8$lambda$iTbMCq5AiGraicD5ZVMw52XWZM(Planar planar, GrayS64 grayS64, GrayS64 grayS65, GrayS64 grayS66, GrayS64 grayS67, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayS64.getIndex(0, i);
        while (i2 < planar.width) {
            grayS64.data[index2] = ((grayS65.data[index] + grayS66.data[index]) + grayS67.data[index]) / 3;
            i2++;
            index++;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$yf8qdaHiVZb2SdvrxPrFPpwWF2s(Planar planar, GrayS64 grayS64, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayS64.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            long j = 0;
            for (int i4 = 0; i4 < i; i4++) {
                j += ((GrayS64[]) planar.bands)[i4].data[index];
            }
            grayS64.data[index2] = j / ((long) i);
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayF32 grayF32) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayF32.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayF32 grayF33 = (GrayF32) planar.getBand(0);
            final GrayF32 grayF34 = (GrayF32) planar.getBand(1);
            final GrayF32 grayF35 = (GrayF32) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda4
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.m674$r8$lambda$OzX5KtHfsVgdBkYe6YqfHc6yD0(planar, grayF32, grayF33, grayF34, grayF35, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda5
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.m671$r8$lambda$Ar_zjdIGgFxRAeHnhsQ2rC5yw(planar, grayF32, numBands, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$OzX5-KtHfsVgdBkYe6YqfHc6yD0, reason: not valid java name */
    public static /* synthetic */ void m674$r8$lambda$OzX5KtHfsVgdBkYe6YqfHc6yD0(Planar planar, GrayF32 grayF32, GrayF32 grayF33, GrayF32 grayF34, GrayF32 grayF35, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayF32.getIndex(0, i);
        while (i2 < planar.width) {
            grayF32.data[index2] = ((grayF33.data[index] + grayF34.data[index]) + grayF35.data[index]) / 3.0f;
            i2++;
            index++;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$Ar--_zjdIGgFxRAeHnhsQ2rC5yw, reason: not valid java name */
    public static /* synthetic */ void m671$r8$lambda$Ar_zjdIGgFxRAeHnhsQ2rC5yw(Planar planar, GrayF32 grayF32, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayF32.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            float f = 0.0f;
            for (int i4 = 0; i4 < i; i4++) {
                f += ((GrayF32[]) planar.bands)[i4].data[index];
            }
            grayF32.data[index2] = f / i;
            i3++;
            index++;
            index2++;
        }
    }

    public static void average(final Planar planar, final GrayF64 grayF64) {
        final int numBands = planar.getNumBands();
        if (numBands == 1) {
            grayF64.setTo(planar.getBand(0));
            return;
        }
        if (numBands == 3) {
            final GrayF64 grayF65 = (GrayF64) planar.getBand(0);
            final GrayF64 grayF66 = (GrayF64) planar.getBand(1);
            final GrayF64 grayF67 = (GrayF64) planar.getBand(2);
            ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ImplConvertPlanarToGray_MT.m675$r8$lambda$_7R9Zu1qeVnHN210XLOdWiyD4Y(planar, grayF64, grayF65, grayF66, grayF67, i);
                }
            });
            return;
        }
        ConcurrencyOps.loopFor(0, planar.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ImplConvertPlanarToGray_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ImplConvertPlanarToGray_MT.$r8$lambda$9aKDVmw16Bu83saXcvlHJxW_x_I(planar, grayF64, numBands, i);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$_7R9Zu1qeVnHN210XL-OdWiyD4Y, reason: not valid java name */
    public static /* synthetic */ void m675$r8$lambda$_7R9Zu1qeVnHN210XLOdWiyD4Y(Planar planar, GrayF64 grayF64, GrayF64 grayF65, GrayF64 grayF66, GrayF64 grayF67, int i) {
        int i2 = 0;
        int index = planar.getIndex(0, i);
        int index2 = grayF64.getIndex(0, i);
        while (i2 < planar.width) {
            grayF64.data[index2] = ((grayF65.data[index] + grayF66.data[index]) + grayF67.data[index]) / 3.0d;
            i2++;
            index++;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$9aKDVmw16Bu83saXcvlHJxW_x_I(Planar planar, GrayF64 grayF64, int i, int i2) {
        int index = planar.getIndex(0, i2);
        int index2 = grayF64.getIndex(0, i2);
        int i3 = 0;
        while (i3 < planar.width) {
            double d = 0.0d;
            for (int i4 = 0; i4 < i; i4++) {
                d += ((GrayF64[]) planar.bands)[i4].data[index];
            }
            grayF64.data[index2] = d / ((double) i);
            i3++;
            index++;
            index2++;
        }
    }
}
