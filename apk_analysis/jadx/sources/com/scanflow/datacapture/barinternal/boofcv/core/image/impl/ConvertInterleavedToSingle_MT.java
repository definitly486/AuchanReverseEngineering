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
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvertInterleavedToSingle_MT {
    public static void average(final InterleavedU8 interleavedU8, final GrayU8 grayU8) {
        final int numBands = interleavedU8.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedU8.height; i++) {
                System.arraycopy(interleavedU8.data, interleavedU8.getIndex(0, i), grayU8.data, grayU8.getIndex(0, i), interleavedU8.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda3
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$riDnPsRaHmHCbtQKKFtkPcj7t7o(interleavedU8, grayU8, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda4
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$JQdCLeM_0LgRC5JA_ksbwp3Nib8(interleavedU8, grayU8, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedU8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda5
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$uEHWLUuunwXloGgMsvEyfgkuzis(interleavedU8, grayU8, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$riDnPsRaHmHCbtQKKFtkPcj7t7o(InterleavedU8 interleavedU8, GrayU8 grayU8, int i) {
        int index = interleavedU8.getIndex(0, i);
        int index2 = grayU8.getIndex(0, i);
        int i2 = interleavedU8.width + index2;
        while (index2 < i2) {
            byte[] bArr = interleavedU8.data;
            int i3 = index + 1;
            int i4 = bArr[index] & UnsignedBytes.MAX_VALUE;
            index += 2;
            grayU8.data[index2] = (byte) ((i4 + (bArr[i3] & UnsignedBytes.MAX_VALUE)) / 2);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$JQdCLeM_0LgRC5JA_ksbwp3Nib8(InterleavedU8 interleavedU8, GrayU8 grayU8, int i) {
        int index = interleavedU8.getIndex(0, i);
        int index2 = grayU8.getIndex(0, i);
        int i2 = interleavedU8.width + index2;
        while (index2 < i2) {
            byte[] bArr = interleavedU8.data;
            int i3 = index + 2;
            int i4 = (bArr[index] & UnsignedBytes.MAX_VALUE) + (bArr[index + 1] & UnsignedBytes.MAX_VALUE);
            index += 3;
            grayU8.data[index2] = (byte) ((i4 + (bArr[i3] & UnsignedBytes.MAX_VALUE)) / 3);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$uEHWLUuunwXloGgMsvEyfgkuzis(InterleavedU8 interleavedU8, GrayU8 grayU8, int i, int i2) {
        int index = interleavedU8.getIndex(0, i2);
        int index2 = grayU8.getIndex(0, i2);
        int i3 = 0;
        while (i3 < interleavedU8.width) {
            int i4 = index + i;
            int i5 = 0;
            while (index < i4) {
                i5 += interleavedU8.data[index] & UnsignedBytes.MAX_VALUE;
                index++;
            }
            grayU8.data[index2] = (byte) (i5 / i);
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedS8 interleavedS8, final GrayS8 grayS8) {
        final int numBands = interleavedS8.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS8.height; i++) {
                System.arraycopy(interleavedS8.data, interleavedS8.getIndex(0, i), grayS8.data, grayS8.getIndex(0, i), interleavedS8.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedS8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda15
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m669$r8$lambda$n9AvgPMorITJHzpwV3kTvUJWps(interleavedS8, grayS8, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedS8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda16
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m670$r8$lambda$oKvFRO3Bq7d3e5VHsHcsE3e6Bw(interleavedS8, grayS8, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedS8.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda17
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$aVSDVDvhCkniPPCpBbRkQqRzXC0(interleavedS8, grayS8, numBands, i2);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$n9AvgPMorITJHzpwV3k-TvUJWps, reason: not valid java name */
    public static /* synthetic */ void m669$r8$lambda$n9AvgPMorITJHzpwV3kTvUJWps(InterleavedS8 interleavedS8, GrayS8 grayS8, int i) {
        int index = interleavedS8.getIndex(0, i);
        int index2 = grayS8.getIndex(0, i);
        int i2 = interleavedS8.width + index2;
        while (index2 < i2) {
            byte[] bArr = interleavedS8.data;
            int i3 = index + 1;
            byte b = bArr[index];
            index += 2;
            grayS8.data[index2] = (byte) ((b + bArr[i3]) / 2);
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$oKvFRO3Bq7d3e5VHsHcs-E3e6Bw, reason: not valid java name */
    public static /* synthetic */ void m670$r8$lambda$oKvFRO3Bq7d3e5VHsHcsE3e6Bw(InterleavedS8 interleavedS8, GrayS8 grayS8, int i) {
        int index = interleavedS8.getIndex(0, i);
        int index2 = grayS8.getIndex(0, i);
        int i2 = interleavedS8.width + index2;
        while (index2 < i2) {
            byte[] bArr = interleavedS8.data;
            int i3 = index + 2;
            int i4 = bArr[index] + bArr[index + 1];
            index += 3;
            grayS8.data[index2] = (byte) ((i4 + bArr[i3]) / 3);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$aVSDVDvhCkniPPCpBbRkQqRzXC0(InterleavedS8 interleavedS8, GrayS8 grayS8, int i, int i2) {
        int index = interleavedS8.getIndex(0, i2);
        int index2 = grayS8.getIndex(0, i2);
        int i3 = 0;
        while (i3 < interleavedS8.width) {
            int i4 = index + i;
            int i5 = 0;
            while (index < i4) {
                i5 += interleavedS8.data[index];
                index++;
            }
            grayS8.data[index2] = (byte) (i5 / i);
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedU16 interleavedU16, final GrayU16 grayU16) {
        final int numBands = interleavedU16.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedU16.height; i++) {
                System.arraycopy(interleavedU16.data, interleavedU16.getIndex(0, i), grayU16.data, grayU16.getIndex(0, i), interleavedU16.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda18
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$yH7Qcw3cXMN7rjU_0la1SuUtXJU(interleavedU16, grayU16, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda19
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m667$r8$lambda$XQGznW16y_LXh6orWIJ061rdA(interleavedU16, grayU16, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedU16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda20
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$avsj8iVfACY9vi1yumEt_jXaxHw(interleavedU16, grayU16, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$yH7Qcw3cXMN7rjU_0la1SuUtXJU(InterleavedU16 interleavedU16, GrayU16 grayU16, int i) {
        int index = interleavedU16.getIndex(0, i);
        int index2 = grayU16.getIndex(0, i);
        int i2 = interleavedU16.width + index2;
        while (index2 < i2) {
            short[] sArr = interleavedU16.data;
            int i3 = index + 1;
            int i4 = sArr[index] & 65535;
            index += 2;
            grayU16.data[index2] = (short) ((i4 + (sArr[i3] & 65535)) / 2);
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$XQ-GznW16y_LXh6orWIJ06-1rdA, reason: not valid java name */
    public static /* synthetic */ void m667$r8$lambda$XQGznW16y_LXh6orWIJ061rdA(InterleavedU16 interleavedU16, GrayU16 grayU16, int i) {
        int index = interleavedU16.getIndex(0, i);
        int index2 = grayU16.getIndex(0, i);
        int i2 = interleavedU16.width + index2;
        while (index2 < i2) {
            short[] sArr = interleavedU16.data;
            int i3 = index + 2;
            int i4 = (sArr[index] & 65535) + (sArr[index + 1] & 65535);
            index += 3;
            grayU16.data[index2] = (short) ((i4 + (sArr[i3] & 65535)) / 3);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$avsj8iVfACY9vi1yumEt_jXaxHw(InterleavedU16 interleavedU16, GrayU16 grayU16, int i, int i2) {
        int index = interleavedU16.getIndex(0, i2);
        int index2 = grayU16.getIndex(0, i2);
        int i3 = 0;
        while (i3 < interleavedU16.width) {
            int i4 = index + i;
            int i5 = 0;
            while (index < i4) {
                i5 += interleavedU16.data[index] & 65535;
                index++;
            }
            grayU16.data[index2] = (short) (i5 / i);
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedS16 interleavedS16, final GrayS16 grayS16) {
        final int numBands = interleavedS16.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS16.height; i++) {
                System.arraycopy(interleavedS16.data, interleavedS16.getIndex(0, i), grayS16.data, grayS16.getIndex(0, i), interleavedS16.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedS16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$DlPNIWt7OEnmEd0qK0p6pOoIDF4(interleavedS16, grayS16, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedS16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda1
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$k0XsislLABNYNJHnh6fgijQYiwo(interleavedS16, grayS16, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedS16.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda2
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$2DipVWSs87EGuhP50Mp9qLmwxhY(interleavedS16, grayS16, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$DlPNIWt7OEnmEd0qK0p6pOoIDF4(InterleavedS16 interleavedS16, GrayS16 grayS16, int i) {
        int index = interleavedS16.getIndex(0, i);
        int index2 = grayS16.getIndex(0, i);
        int i2 = interleavedS16.width + index2;
        while (index2 < i2) {
            short[] sArr = interleavedS16.data;
            int i3 = index + 1;
            short s = sArr[index];
            index += 2;
            grayS16.data[index2] = (short) ((s + sArr[i3]) / 2);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$k0XsislLABNYNJHnh6fgijQYiwo(InterleavedS16 interleavedS16, GrayS16 grayS16, int i) {
        int index = interleavedS16.getIndex(0, i);
        int index2 = grayS16.getIndex(0, i);
        int i2 = interleavedS16.width + index2;
        while (index2 < i2) {
            short[] sArr = interleavedS16.data;
            int i3 = index + 2;
            int i4 = sArr[index] + sArr[index + 1];
            index += 3;
            grayS16.data[index2] = (short) ((i4 + sArr[i3]) / 3);
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$2DipVWSs87EGuhP50Mp9qLmwxhY(InterleavedS16 interleavedS16, GrayS16 grayS16, int i, int i2) {
        int index = interleavedS16.getIndex(0, i2);
        int index2 = grayS16.getIndex(0, i2);
        int i3 = 0;
        while (i3 < interleavedS16.width) {
            int i4 = index + i;
            int i5 = 0;
            while (index < i4) {
                i5 += interleavedS16.data[index];
                index++;
            }
            grayS16.data[index2] = (short) (i5 / i);
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedS32 interleavedS32, final GrayS32 grayS32) {
        final int numBands = interleavedS32.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS32.height; i++) {
                System.arraycopy(interleavedS32.data, interleavedS32.getIndex(0, i), grayS32.data, grayS32.getIndex(0, i), interleavedS32.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda21
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$RkdK0yv5XuZqCKGNhF0HJt0VfmI(interleavedS32, grayS32, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda22
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$btWf_DldsidxkJWdtSr_wDKrmYU(interleavedS32, grayS32, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedS32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda23
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$MbarpG0UEaKaFxduU3XobYl3Gxk(interleavedS32, grayS32, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$RkdK0yv5XuZqCKGNhF0HJt0VfmI(InterleavedS32 interleavedS32, GrayS32 grayS32, int i) {
        int index = interleavedS32.getIndex(0, i);
        int index2 = grayS32.getIndex(0, i);
        int i2 = interleavedS32.width + index2;
        while (index2 < i2) {
            int[] iArr = interleavedS32.data;
            int i3 = index + 1;
            int i4 = iArr[index];
            index += 2;
            grayS32.data[index2] = (i4 + iArr[i3]) / 2;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$btWf_DldsidxkJWdtSr_wDKrmYU(InterleavedS32 interleavedS32, GrayS32 grayS32, int i) {
        int index = interleavedS32.getIndex(0, i);
        int index2 = grayS32.getIndex(0, i);
        int i2 = interleavedS32.width + index2;
        while (index2 < i2) {
            int[] iArr = interleavedS32.data;
            int i3 = index + 2;
            int i4 = iArr[index] + iArr[index + 1];
            index += 3;
            grayS32.data[index2] = (i4 + iArr[i3]) / 3;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$MbarpG0UEaKaFxduU3XobYl3Gxk(InterleavedS32 interleavedS32, GrayS32 grayS32, int i, int i2) {
        int index = interleavedS32.getIndex(0, i2);
        int index2 = grayS32.getIndex(0, i2);
        int i3 = 0;
        while (i3 < interleavedS32.width) {
            int i4 = index + i;
            int i5 = 0;
            while (index < i4) {
                i5 += interleavedS32.data[index];
                index++;
            }
            grayS32.data[index2] = i5 / i;
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedS64 interleavedS64, final GrayS64 grayS64) {
        final int numBands = interleavedS64.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedS64.height; i++) {
                System.arraycopy(interleavedS64.data, interleavedS64.getIndex(0, i), grayS64.data, grayS64.getIndex(0, i), interleavedS64.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedS64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda6
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$LDoexoirWL2DfsjEJ7qJ1zTa0oI(interleavedS64, grayS64, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedS64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda7
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$mIOLyf5RTzLfwv6gU6KyWzw9wKc(interleavedS64, grayS64, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedS64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda8
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m664$r8$lambda$6xtMlq5hIWO795vx8bDdPAY6h4(interleavedS64, grayS64, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$LDoexoirWL2DfsjEJ7qJ1zTa0oI(InterleavedS64 interleavedS64, GrayS64 grayS64, int i) {
        int index = interleavedS64.getIndex(0, i);
        int index2 = grayS64.getIndex(0, i);
        int i2 = interleavedS64.width + index2;
        while (index2 < i2) {
            long[] jArr = interleavedS64.data;
            int i3 = index + 1;
            long j = jArr[index];
            index += 2;
            grayS64.data[index2] = (j + jArr[i3]) / 2;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$mIOLyf5RTzLfwv6gU6KyWzw9wKc(InterleavedS64 interleavedS64, GrayS64 grayS64, int i) {
        int index = interleavedS64.getIndex(0, i);
        int index2 = grayS64.getIndex(0, i);
        int i2 = interleavedS64.width + index2;
        while (index2 < i2) {
            long[] jArr = interleavedS64.data;
            int i3 = index + 2;
            long j = jArr[index] + jArr[index + 1];
            index += 3;
            grayS64.data[index2] = (j + jArr[i3]) / 3;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$6xtMlq5hIWO795vx8bDdPA-Y6h4, reason: not valid java name */
    public static /* synthetic */ void m664$r8$lambda$6xtMlq5hIWO795vx8bDdPAY6h4(InterleavedS64 interleavedS64, GrayS64 grayS64, int i, int i2) {
        int i3 = 0;
        int index = interleavedS64.getIndex(0, i2);
        int index2 = grayS64.getIndex(0, i2);
        while (i3 < interleavedS64.width) {
            int i4 = index + i;
            long j = 0;
            while (index < i4) {
                j += interleavedS64.data[index];
                index++;
            }
            grayS64.data[index2] = j / ((long) i);
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedF32 interleavedF32, final GrayF32 grayF32) {
        final int numBands = interleavedF32.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedF32.height; i++) {
                System.arraycopy(interleavedF32.data, interleavedF32.getIndex(0, i), grayF32.data, grayF32.getIndex(0, i), interleavedF32.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda9
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$5LIvScvvraMZc49VIAKn9YLb68k(interleavedF32, grayF32, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda10
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$9pcRhd11XNgsR0XGri3iJLhuw0I(interleavedF32, grayF32, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda11
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.$r8$lambda$0F8cJuxpb2kKhxLuyekw8GbQAdg(interleavedF32, grayF32, numBands, i2);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$5LIvScvvraMZc49VIAKn9YLb68k(InterleavedF32 interleavedF32, GrayF32 grayF32, int i) {
        int index = interleavedF32.getIndex(0, i);
        int index2 = grayF32.getIndex(0, i);
        int i2 = interleavedF32.width + index2;
        while (index2 < i2) {
            float[] fArr = interleavedF32.data;
            int i3 = index + 1;
            float f = fArr[index];
            index += 2;
            grayF32.data[index2] = (f + fArr[i3]) / 2.0f;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$9pcRhd11XNgsR0XGri3iJLhuw0I(InterleavedF32 interleavedF32, GrayF32 grayF32, int i) {
        int index = interleavedF32.getIndex(0, i);
        int index2 = grayF32.getIndex(0, i);
        int i2 = interleavedF32.width + index2;
        while (index2 < i2) {
            float[] fArr = interleavedF32.data;
            int i3 = index + 2;
            float f = fArr[index] + fArr[index + 1];
            index += 3;
            grayF32.data[index2] = (f + fArr[i3]) / 3.0f;
            index2++;
        }
    }

    public static /* synthetic */ void $r8$lambda$0F8cJuxpb2kKhxLuyekw8GbQAdg(InterleavedF32 interleavedF32, GrayF32 grayF32, int i, int i2) {
        int i3 = 0;
        int index = interleavedF32.getIndex(0, i2);
        int index2 = grayF32.getIndex(0, i2);
        while (i3 < interleavedF32.width) {
            int i4 = index + i;
            float f = 0.0f;
            while (index < i4) {
                f += interleavedF32.data[index];
                index++;
            }
            grayF32.data[index2] = f / i;
            i3++;
            index2++;
        }
    }

    public static void average(final InterleavedF64 interleavedF64, final GrayF64 grayF64) {
        final int numBands = interleavedF64.getNumBands();
        if (numBands == 1) {
            for (int i = 0; i < interleavedF64.height; i++) {
                System.arraycopy(interleavedF64.data, interleavedF64.getIndex(0, i), grayF64.data, grayF64.getIndex(0, i), interleavedF64.width);
            }
            return;
        }
        if (numBands == 2) {
            ConcurrencyOps.loopFor(0, interleavedF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda12
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m665$r8$lambda$6y3JVm1u78equ_09sI4ZdEfQ5k(interleavedF64, grayF64, i2);
                }
            });
        } else if (numBands == 3) {
            ConcurrencyOps.loopFor(0, interleavedF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda13
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m668$r8$lambda$esPZXNSAxz50H_xn8XDJsEHXw(interleavedF64, grayF64, i2);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, interleavedF64.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.core.image.impl.ConvertInterleavedToSingle_MT$$ExternalSyntheticLambda14
                @Override // java.util.function.IntConsumer
                public final void accept(int i2) {
                    ConvertInterleavedToSingle_MT.m666$r8$lambda$BolU2stR5MgyMbPipUEkNXEPkc(interleavedF64, grayF64, numBands, i2);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$6y3JVm1u78equ-_09sI4ZdEfQ5k, reason: not valid java name */
    public static /* synthetic */ void m665$r8$lambda$6y3JVm1u78equ_09sI4ZdEfQ5k(InterleavedF64 interleavedF64, GrayF64 grayF64, int i) {
        int index = interleavedF64.getIndex(0, i);
        int index2 = grayF64.getIndex(0, i);
        int i2 = interleavedF64.width + index2;
        while (index2 < i2) {
            double[] dArr = interleavedF64.data;
            int i3 = index + 1;
            double d = dArr[index];
            index += 2;
            grayF64.data[index2] = (d + dArr[i3]) / 2.0d;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$esPZXNSA-xz50H_xn8X-DJsEHXw, reason: not valid java name */
    public static /* synthetic */ void m668$r8$lambda$esPZXNSAxz50H_xn8XDJsEHXw(InterleavedF64 interleavedF64, GrayF64 grayF64, int i) {
        int index = interleavedF64.getIndex(0, i);
        int index2 = grayF64.getIndex(0, i);
        int i2 = interleavedF64.width + index2;
        while (index2 < i2) {
            double[] dArr = interleavedF64.data;
            int i3 = index + 2;
            double d = dArr[index] + dArr[index + 1];
            index += 3;
            grayF64.data[index2] = (d + dArr[i3]) / 3.0d;
            index2++;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$BolU2-stR5MgyMbPipUEkNXEPkc, reason: not valid java name */
    public static /* synthetic */ void m666$r8$lambda$BolU2stR5MgyMbPipUEkNXEPkc(InterleavedF64 interleavedF64, GrayF64 grayF64, int i, int i2) {
        int i3 = 0;
        int index = interleavedF64.getIndex(0, i2);
        int index2 = grayF64.getIndex(0, i2);
        while (i3 < interleavedF64.width) {
            int i4 = index + i;
            double d = 0.0d;
            while (index < i4) {
                d += interleavedF64.data[index];
                index++;
            }
            grayF64.data[index2] = d / ((double) i);
            i3++;
            index2++;
        }
    }
}
