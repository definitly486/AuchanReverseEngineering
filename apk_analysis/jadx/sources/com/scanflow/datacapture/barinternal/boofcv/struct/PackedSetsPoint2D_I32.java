package com.scanflow.datacapture.barinternal.boofcv.struct;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;

/* JADX INFO: loaded from: classes.dex */
public class PackedSetsPoint2D_I32 {
    final int blockLength;
    final DogArray blocks;
    final DogArray sets;
    int tailBlockSize;

    public PackedSetsPoint2D_I32(int i) {
        this.sets = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.struct.PackedSetsPoint2D_I32$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
            public final Object newInstance() {
                return new BlockIndexLength();
            }
        });
        if (i < 2) {
            throw new IllegalArgumentException("Block length must be more than 2");
        }
        this.blockLength = i + (i % 2);
        DogArray dogArray = new DogArray(int[].class, new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.struct.PackedSetsPoint2D_I32$$ExternalSyntheticLambda1
            @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
            public final Object newInstance() {
                return PackedSetsPoint2D_I32.$r8$lambda$EEm76jKBBsVFr6fPj1OH5D2KWJY(this.f$0);
            }
        });
        this.blocks = dogArray;
        dogArray.grow();
    }

    public static /* synthetic */ int[] $r8$lambda$EEm76jKBBsVFr6fPj1OH5D2KWJY(PackedSetsPoint2D_I32 packedSetsPoint2D_I32) {
        return new int[packedSetsPoint2D_I32.blockLength];
    }

    public PackedSetsPoint2D_I32() {
        this(2000);
    }

    public void reset() {
        this.tailBlockSize = 0;
        this.blocks.reset();
        this.blocks.grow();
        this.sets.reset();
    }

    public void grow() {
        if (this.tailBlockSize >= this.blockLength) {
            this.tailBlockSize = 0;
            this.blocks.grow();
        }
        BlockIndexLength blockIndexLength = (BlockIndexLength) this.sets.grow();
        blockIndexLength.block = this.blocks.size - 1;
        blockIndexLength.start = this.tailBlockSize;
        blockIndexLength.length = 0;
    }

    public void removeTail() {
        BlockIndexLength blockIndexLength = (BlockIndexLength) this.sets.getTail();
        while (true) {
            DogArray dogArray = this.blocks;
            if (dogArray.size - 1 != blockIndexLength.block) {
                dogArray.removeTail();
            } else {
                this.tailBlockSize = blockIndexLength.start;
                this.sets.removeTail();
                return;
            }
        }
    }

    public void addPointToTail(int i, int i2) {
        int[] iArr;
        if (this.sets.size == 0) {
            grow();
        }
        BlockIndexLength blockIndexLength = (BlockIndexLength) this.sets.getTail();
        int i3 = blockIndexLength.start + (blockIndexLength.length * 2);
        int i4 = blockIndexLength.block + (i3 / this.blockLength);
        DogArray dogArray = this.blocks;
        if (i4 == dogArray.size) {
            this.tailBlockSize = 0;
            iArr = (int[]) dogArray.grow();
        } else {
            iArr = (int[]) dogArray.get(i4);
        }
        this.tailBlockSize += 2;
        int i5 = i3 % this.blockLength;
        iArr[i5] = i;
        iArr[i5 + 1] = i2;
        blockIndexLength.length++;
    }

    public int size() {
        return this.sets.size;
    }

    public void getSet(int i, DogArray dogArray) {
        dogArray.reset();
        BlockIndexLength blockIndexLength = (BlockIndexLength) this.sets.get(i);
        for (int i2 = 0; i2 < blockIndexLength.length; i2++) {
            int i3 = blockIndexLength.start + (i2 * 2);
            int i4 = blockIndexLength.block;
            int i5 = this.blockLength;
            int i6 = i4 + (i3 / i5);
            int i7 = i3 % i5;
            int[] iArr = (int[]) this.blocks.get(i6);
            ((Point2D_I32) dogArray.grow()).setTo(iArr[i7], iArr[i7 + 1]);
        }
    }

    public int sizeOfTail() {
        DogArray dogArray = this.sets;
        if (dogArray.size == 0) {
            return 0;
        }
        return ((BlockIndexLength) dogArray.getTail()).length;
    }
}
