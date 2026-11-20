package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import com.scanflow.datacapture.barinternal.boofcv.misc.CircularIndex;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPolygons2D_I32;
import com.scanflow.datacapture.barinternal.georegression.metric.Distance2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogLinkedList;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class PolylineSplitMerge {
    private CandidatePolyline bestPolyline;
    private boolean fatalError;
    private boolean loops = true;
    private boolean convex = false;
    private int maxSides = Integer.MAX_VALUE;
    private int minSides = 3;
    private int minimumSideLength = 10;
    private final ConfigLength extraConsider = ConfigLength.relative(1.0d, 0.0d);
    private double cornerScorePenalty = 0.25d;
    private double thresholdSideSplitScore = 0.0d;
    int maxNumberOfSideSamples = 50;
    double convexTest = 2.5d;
    final ConfigLength maxSideError = ConfigLength.relative(0.1d, 3.0d);
    private final LineSegment2D_F64 line = new LineSegment2D_F64();
    DogLinkedList list = new DogLinkedList();
    DogArray corners = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.PolylineSplitMerge$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new PolylineSplitMerge.Corner();
        }
    });
    private SplitSelector splitter = new MaximumLineDistance();
    private final SplitResults resultsA = new SplitResults();
    private final SplitResults resultsB = new SplitResults();
    private final DogArray polylines = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.PolylineSplitMerge$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new PolylineSplitMerge.CandidatePolyline();
        }
    });
    ErrorValue sideError = new ErrorValue();

    public boolean isLoops() {
        return this.loops;
    }

    public void setLoops(boolean z) {
        this.loops = z;
    }

    public void setConvex(boolean z) {
        this.convex = z;
    }

    public void setMaxSides(int i) {
        this.maxSides = i;
    }

    public int getMinSides() {
        return this.minSides;
    }

    public void setMinSides(int i) {
        this.minSides = i;
    }

    public void setCornerScorePenalty(double d) {
        this.cornerScorePenalty = d;
    }

    public void setThresholdSideSplitScore(double d) {
        this.thresholdSideSplitScore = d;
    }

    public void setMaxNumberOfSideSamples(int i) {
        this.maxNumberOfSideSamples = i;
    }

    public void setConvexTest(double d) {
        this.convexTest = d;
    }

    public boolean process(List list) {
        reset();
        if (this.loops) {
            if (list.size() < 3 || !findInitialTriangle(list)) {
                return false;
            }
        } else {
            if (list.size() < 2) {
                return false;
            }
            addCorner(0);
            addCorner(list.size() - 1);
            initializeScore(list, false);
        }
        savePolyline();
        sequentialSideFit(list, this.loops);
        if (this.fatalError) {
            return false;
        }
        int i = this.loops ? 3 : 2;
        double d = Double.MAX_VALUE;
        int i2 = -1;
        for (int i3 = 0; i3 < Math.min(this.maxSides - (i - 1), this.polylines.size); i3++) {
            if (((CandidatePolyline) this.polylines.get(i3)).score < d) {
                CandidatePolyline candidatePolyline = (CandidatePolyline) this.polylines.get(i3);
                this.bestPolyline = candidatePolyline;
                d = candidatePolyline.score;
                i2 = i3 + i;
            }
        }
        if (i2 < this.minSides || this.bestPolyline == null) {
            return false;
        }
        int i4 = i2 - 1;
        for (int i5 = 0; i5 < i2; i5++) {
            double dCompute = this.maxSideError.compute(((Point2D_I32) list.get(this.bestPolyline.splits.get(i5))).distance((Point2D_I32) list.get(this.bestPolyline.splits.get(i4))));
            if (this.bestPolyline.sideErrors.get(i5) >= dCompute * dCompute) {
                this.bestPolyline = null;
                return false;
            }
            i4 = i5;
        }
        return true;
    }

    private void sequentialSideFit(List list, boolean z) {
        DogLinkedList.Element elementSelectCornerToRemove;
        int i = this.maxSides;
        int iComputeI = i + this.extraConsider.computeI(i);
        if (iComputeI <= 0) {
            iComputeI = list.size();
        }
        while (this.list.size() < iComputeI && !this.fatalError && increaseNumberOfSidesByOne(list, z)) {
        }
        while (!this.fatalError && (elementSelectCornerToRemove = selectCornerToRemove(list, this.sideError, z)) != null) {
            removeCornerAndSavePolyline(elementSelectCornerToRemove, this.sideError.value);
        }
    }

    private void reset() {
        this.list.reset();
        this.corners.reset();
        this.polylines.reset();
        this.bestPolyline = null;
        this.fatalError = false;
    }

    boolean savePolyline() {
        CandidatePolyline candidatePolyline;
        int i = this.loops ? 3 : 2;
        int size = this.list.size();
        DogArray dogArray = this.polylines;
        if (size <= (dogArray.size + i) - 1) {
            candidatePolyline = (CandidatePolyline) dogArray.get(this.list.size() - i);
            if (candidatePolyline.splits.size != this.list.size()) {
                throw new RuntimeException("Egads saved polylines aren't in the expected order");
            }
        } else {
            candidatePolyline = (CandidatePolyline) dogArray.grow();
            candidatePolyline.reset();
            candidatePolyline.score = Double.MAX_VALUE;
        }
        double dComputeScore = computeScore(this.list, this.cornerScorePenalty, this.loops);
        if (candidatePolyline.score <= dComputeScore) {
            return false;
        }
        candidatePolyline.score = dComputeScore;
        candidatePolyline.splits.reset();
        candidatePolyline.sideErrors.reset();
        double dMax = 0.0d;
        for (DogLinkedList.Element head = this.list.getHead(); head != null; head = head.next) {
            dMax = Math.max(dMax, ((Corner) head.object).sideError);
            candidatePolyline.splits.add(((Corner) head.object).index);
            candidatePolyline.sideErrors.add(((Corner) head.object).sideError);
        }
        candidatePolyline.maxSideError = dMax;
        return true;
    }

    static double computeScore(DogLinkedList dogLinkedList, double d, boolean z) {
        DogLinkedList.Element tail = z ? null : dogLinkedList.getTail();
        double d2 = 0.0d;
        for (DogLinkedList.Element head = dogLinkedList.getHead(); head != tail; head = head.next) {
            d2 += ((Corner) head.object).sideError;
        }
        int size = dogLinkedList.size();
        if (!z) {
            size--;
        }
        double d3 = size;
        return (d2 / d3) + (d * d3);
    }

    boolean findInitialTriangle(List list) {
        int iFindCornerSeed = findCornerSeed(list);
        if (this.convex && !isConvexUsingMaxDistantPoints(list, 0, iFindCornerSeed)) {
            return false;
        }
        this.splitter.selectSplitPoint(list, 0, iFindCornerSeed, this.resultsA);
        this.splitter.selectSplitPoint(list, iFindCornerSeed, 0, this.resultsB);
        if (this.splitter.compareScore(this.resultsA.score, this.resultsB.score) >= 0) {
            addCorner(this.resultsA.index);
            addCorner(iFindCornerSeed);
        } else {
            addCorner(iFindCornerSeed);
            addCorner(this.resultsB.index);
        }
        addCorner(maximumDistance(list, ((Corner) this.list.getHead().object).index, ((Corner) this.list.getHead().next.object).index));
        ensureTriangleOrder(list);
        return initializeScore(list, true);
    }

    private boolean initializeScore(List list, boolean z) {
        double dComputeSideError;
        DogLinkedList.Element head = this.list.getHead();
        DogLinkedList.Element tail = z ? null : this.list.getTail();
        while (head != tail) {
            if (this.convex && !isSideConvex(list, head)) {
                return false;
            }
            DogLinkedList.Element element = head.next;
            if (element == null) {
                dComputeSideError = computeSideError(list, ((Corner) head.object).index, ((Corner) this.list.getHead().object).index);
            } else {
                dComputeSideError = computeSideError(list, ((Corner) head.object).index, ((Corner) element.object).index);
            }
            ((Corner) head.object).sideError = dComputeSideError;
            head = element;
        }
        DogLinkedList.Element head2 = this.list.getHead();
        while (true) {
            boolean z2 = true;
            if (head2 == tail) {
                return true;
            }
            if (this.list.size() >= this.minSides) {
                z2 = false;
            }
            computePotentialSplitScore(list, head2, z2);
            head2 = head2.next;
        }
    }

    void ensureTriangleOrder(List list) {
        DogLinkedList.Element head = this.list.getHead();
        Corner corner = (Corner) head.object;
        DogLinkedList.Element element = head.next;
        Corner corner2 = (Corner) element.object;
        Corner corner3 = (Corner) element.next.object;
        if (CircularIndex.distanceP(corner.index, corner2.index, list.size()) > CircularIndex.distanceP(corner.index, corner3.index, list.size())) {
            this.list.reset();
            this.list.pushTail(corner);
            this.list.pushTail(corner3);
            this.list.pushTail(corner2);
        }
    }

    DogLinkedList.Element addCorner(int i) {
        Corner corner = (Corner) this.corners.grow();
        corner.reset();
        corner.index = i;
        this.list.pushTail(corner);
        return this.list.getTail();
    }

    boolean increaseNumberOfSidesByOne(List list, boolean z) {
        DogLinkedList.Element elementSelectCornerToSplit = selectCornerToSplit(z);
        if (elementSelectCornerToSplit == null) {
            return false;
        }
        Object obj = elementSelectCornerToSplit.object;
        ((Corner) obj).sideError = ((Corner) obj).splitError0;
        Corner corner = (Corner) this.corners.grow();
        corner.reset();
        Object obj2 = elementSelectCornerToSplit.object;
        corner.index = ((Corner) obj2).splitLocation;
        corner.sideError = ((Corner) obj2).splitError1;
        DogLinkedList.Element elementInsertAfter = this.list.insertAfter(elementSelectCornerToSplit, corner);
        if (this.convex && !isSideConvex(list, elementSelectCornerToSplit)) {
            return false;
        }
        computePotentialSplitScore(list, elementInsertAfter, this.list.size() < this.minSides);
        computePotentialSplitScore(list, elementSelectCornerToSplit, this.list.size() < this.minSides);
        savePolyline();
        return true;
    }

    boolean isSideConvex(List list, DogLinkedList.Element element) {
        DogLinkedList.Element next = next(element);
        return ((double) CircularIndex.distanceP(((Corner) element.object).index, ((Corner) next.object).index, list.size())) < ((Point2D_I32) list.get(((Corner) element.object).index)).distance((Point2D_I32) list.get(((Corner) next.object).index)) * this.convexTest;
    }

    DogLinkedList.Element selectCornerToSplit(boolean z) {
        double d = this.convex ? 0.0d : -1.7976931348623157E308d;
        DogLinkedList.Element head = this.list.getHead();
        DogLinkedList.Element element = null;
        DogLinkedList.Element tail = z ? null : this.list.getTail();
        while (head != tail) {
            Corner corner = (Corner) head.object;
            if (!corner.splitable) {
                head = head.next;
            } else {
                double d2 = ((corner.sideError * 2.0d) - corner.splitError0) - corner.splitError1;
                if (d2 < 0.0d) {
                    d2 = -d2;
                }
                if (d2 > d) {
                    element = head;
                    d = d2;
                }
                head = head.next;
            }
        }
        return element;
    }

    DogLinkedList.Element selectCornerToRemove(List list, ErrorValue errorValue, boolean z) {
        DogLinkedList.Element head;
        DogLinkedList.Element tail;
        DogLinkedList.Element element = null;
        if (this.list.size() <= 3) {
            return null;
        }
        if (z) {
            head = this.list.getHead();
            tail = null;
        } else {
            head = this.list.getHead().next;
            tail = this.list.getTail();
        }
        double d = -1.7976931348623157E308d;
        while (head != tail) {
            DogLinkedList.Element elementPrevious = previous(head);
            DogLinkedList.Element next = next(head);
            Object obj = elementPrevious.object;
            double d2 = ((((Corner) obj).sideError + ((Corner) head.object).sideError) / 2.0d) + this.cornerScorePenalty;
            double dComputeSideError = computeSideError(list, ((Corner) obj).index, ((Corner) next.object).index);
            double d3 = d2 - dComputeSideError;
            if (d3 > d) {
                errorValue.value = dComputeSideError;
                element = head;
                d = d3;
            }
            head = head.next;
        }
        Objects.requireNonNull(element);
        return element;
    }

    boolean removeCornerAndSavePolyline(DogLinkedList.Element element, double d) {
        ((Corner) previous(element).object).sideError = d;
        this.list.remove(element);
        return savePolyline();
    }

    static int findCornerSeed(List list) {
        Point2D_I32 point2D_I32 = (Point2D_I32) list.get(0);
        int i = -1;
        double d = -1.7976931348623157E308d;
        for (int i2 = 1; i2 < list.size(); i2++) {
            double dDistanceSq = distanceSq(point2D_I32, (Point2D_I32) list.get(i2));
            if (dDistanceSq > d) {
                i = i2;
                d = dDistanceSq;
            }
        }
        return i;
    }

    static int maximumDistance(List list, int i, int i2) {
        Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) list.get(i2);
        int i3 = -1;
        double d = -1.7976931348623157E308d;
        for (int i4 = 0; i4 < list.size(); i4++) {
            Point2D_I32 point2D_I34 = (Point2D_I32) list.get(i4);
            double dDistanceAbs = distanceAbs(point2D_I32, point2D_I34) + distanceAbs(point2D_I33, point2D_I34);
            if (dDistanceAbs > d) {
                i3 = i4;
                d = dDistanceAbs;
            }
        }
        return i3;
    }

    double computeSideError(List list, int i, int i2) {
        double d;
        int iMin;
        assignLine(list, i, i2, this.line);
        int i3 = 0;
        if (i2 >= i) {
            int i4 = (i2 - i) - 1;
            iMin = Math.min(i4, this.maxNumberOfSideSamples);
            double dDistanceSq = 0.0d;
            while (i3 < iMin) {
                Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i + 1 + ((i4 * i3) / iMin));
                dDistanceSq += Distance2D_F64.distanceSq(this.line, point2D_I32.x, point2D_I32.y);
                i3++;
            }
            d = dDistanceSq / ((double) iMin);
        } else {
            int size = ((list.size() - i) - 1) + i2;
            int iMin2 = Math.min(size, this.maxNumberOfSideSamples);
            double dDistanceSq2 = 0.0d;
            while (i3 < iMin2) {
                Point2D_I32 point2D_I33 = (Point2D_I32) list.get(((i + 1) + ((size * i3) / iMin2)) % list.size());
                dDistanceSq2 += Distance2D_F64.distanceSq(this.line, point2D_I33.x, point2D_I33.y);
                i3++;
            }
            d = dDistanceSq2 / ((double) iMin2);
            iMin = iMin2;
        }
        if (iMin > 0) {
            return d;
        }
        return 0.0d;
    }

    void computePotentialSplitScore(List list, DogLinkedList.Element element, boolean z) {
        DogLinkedList.Element next = next(element);
        ((Corner) element.object).splitable = canBeSplit(list, element, z);
        if (((Corner) element.object).splitable) {
            setSplitVariables(list, element, next);
        }
    }

    void setSplitVariables(List list, DogLinkedList.Element element, DogLinkedList.Element element2) {
        this.splitter.selectSplitPoint(list, CircularIndex.plusPOffset(((Corner) element.object).index, this.minimumSideLength, list.size()), CircularIndex.minusPOffset(((Corner) element2.object).index, this.minimumSideLength, list.size()), this.resultsA);
        if (this.convex && UtilPolygons2D_I32.isPositiveZ((Point2D_I32) list.get(((Corner) element.object).index), (Point2D_I32) list.get(this.resultsA.index), (Point2D_I32) list.get(((Corner) next(element).object).index))) {
            ((Corner) element.object).splitable = false;
            return;
        }
        int iDistanceP = CircularIndex.distanceP(((Corner) element.object).index, this.resultsA.index, list.size());
        if (iDistanceP < this.minimumSideLength || list.size() - iDistanceP < this.minimumSideLength) {
            throw new RuntimeException("Should be impossible");
        }
        Object obj = element.object;
        int i = this.resultsA.index;
        ((Corner) obj).splitLocation = i;
        ((Corner) obj).splitError0 = computeSideError(list, ((Corner) obj).index, i);
        ((Corner) element.object).splitError1 = computeSideError(list, this.resultsA.index, ((Corner) element2.object).index);
        if (((Corner) element.object).splitLocation >= list.size()) {
            throw new RuntimeException("Egads");
        }
    }

    boolean canBeSplit(List list, DogLinkedList.Element element, boolean z) {
        if (CircularIndex.distanceP(((Corner) element.object).index, ((Corner) next(element).object).index, list.size()) <= this.minimumSideLength * 2) {
            return false;
        }
        return z || ((Corner) element.object).sideError > this.thresholdSideSplitScore;
    }

    DogLinkedList.Element next(DogLinkedList.Element element) {
        DogLinkedList.Element element2 = element.next;
        return element2 == null ? this.list.getHead() : element2;
    }

    DogLinkedList.Element previous(DogLinkedList.Element element) {
        DogLinkedList.Element element2 = element.prev;
        return element2 == null ? this.list.getTail() : element2;
    }

    static boolean isConvexUsingMaxDistantPoints(List list, int i, int i2) {
        int iSqrt = (int) ((Math.sqrt(distanceSq((Point2D_I32) list.get(i), (Point2D_I32) list.get(i2))) * 4.141592653589793d) + 0.5d);
        return CircularIndex.distanceP(i, i2, list.size()) <= iSqrt && CircularIndex.distanceP(i2, i, list.size()) <= iSqrt;
    }

    static double distanceSq(Point2D_I32 point2D_I32, Point2D_I32 point2D_I33) {
        double d = point2D_I33.x - point2D_I32.x;
        double d2 = point2D_I33.y - point2D_I32.y;
        return (d * d) + (d2 * d2);
    }

    static double distanceAbs(Point2D_I32 point2D_I32, Point2D_I32 point2D_I33) {
        return Math.abs(point2D_I33.x - point2D_I32.x) + Math.abs(point2D_I33.y - point2D_I32.y);
    }

    public static void assignLine(List list, int i, int i2, LineParametric2D_F64 lineParametric2D_F64) {
        Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) list.get(i2);
        Point2D_F64 point2D_F64 = lineParametric2D_F64.p;
        int i3 = point2D_I32.x;
        point2D_F64.x = i3;
        int i4 = point2D_I32.y;
        point2D_F64.y = i4;
        Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
        vector2D_F64.x = point2D_I33.x - i3;
        vector2D_F64.y = point2D_I33.y - i4;
    }

    public static void assignLine(List list, int i, int i2, LineSegment2D_F64 lineSegment2D_F64) {
        Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) list.get(i2);
        lineSegment2D_F64.a.setTo(point2D_I32.x, point2D_I32.y);
        lineSegment2D_F64.b.setTo(point2D_I33.x, point2D_I33.y);
    }

    public CandidatePolyline getBestPolyline() {
        return this.bestPolyline;
    }

    static class SplitResults {
        public int index;
        public double score;

        SplitResults() {
        }
    }

    public static class Corner {
        public int index;
        public double sideError;
        public double splitError0;
        public double splitError1;
        public int splitLocation;
        public boolean splitable;

        public void reset() {
            this.index = -1;
            this.sideError = -1.0d;
            this.splitLocation = -1;
            this.splitError1 = -1.0d;
            this.splitError0 = -1.0d;
            this.splitable = true;
        }
    }

    public static class CandidatePolyline {
        public double maxSideError;
        public double score;
        public DogArray_I32 splits = new DogArray_I32();
        public DogArray_F64 sideErrors = new DogArray_F64();

        public void reset() {
            this.splits.reset();
            this.sideErrors.reset();
            this.score = Double.NaN;
            this.maxSideError = Double.NaN;
        }
    }

    static class ErrorValue {
        public double value;

        ErrorValue() {
        }
    }

    public void setMinimumSideLength(int i) {
        if (i <= 0) {
            throw new IllegalArgumentException("Minimum length must be at least 1");
        }
        this.minimumSideLength = i;
    }

    public void setExtraConsider(ConfigLength configLength) {
        this.extraConsider.setTo(configLength);
    }

    public void setMaxSideError(ConfigLength configLength) {
        this.maxSideError.setTo(configLength);
    }
}
